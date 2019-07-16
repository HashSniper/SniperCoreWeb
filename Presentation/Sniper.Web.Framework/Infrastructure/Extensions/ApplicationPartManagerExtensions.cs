using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Sniper.Core;
using Sniper.Core.ComponentModel;
using Sniper.Core.Configuration;
using Sniper.Core.Infrastructure;
using Sniper.Core.Redis;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Sniper.Web.Framework.Infrastructure.Extensions
{
    public static class ApplicationPartManagerExtensions
    {
        #region Fileds
        private static readonly INopFileProvider _fileProvider;
        private static readonly List<string> _baseAppLibraries;
        private static readonly Dictionary<string, PluginLoadedAssemblyInfo> _loadedAssemblies = new Dictionary<string, PluginLoadedAssemblyInfo>();
        private static readonly ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();
        #endregion


        #region Ctor
        static ApplicationPartManagerExtensions()
        {
            _fileProvider = CommonHelper.DefaultFileProvider;

            _baseAppLibraries = new List<string>();

            _baseAppLibraries.AddRange(_fileProvider.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                .Select(fileName => _fileProvider.GetFileName(fileName)));

            if (!AppDomain.CurrentDomain.BaseDirectory.Equals(Environment.CurrentDirectory, StringComparison.InvariantCultureIgnoreCase))
            {
                _baseAppLibraries.AddRange(_fileProvider.GetFiles(Environment.CurrentDirectory, "*.dll")
                    .Select(fileName => _fileProvider.GetFileName(fileName)));
            }

            var refsPathName = _fileProvider.Combine(Environment.CurrentDirectory, SniperPluginDefaults.RefsPathName);
            if (_fileProvider.DirectoryExists(refsPathName))
            {
                _baseAppLibraries.AddRange(_fileProvider.GetFiles(refsPathName, "*.dll")
                    .Select(fileName => _fileProvider.GetFileName(fileName)));
            }


        }
        #endregion

        private static IPluginsInfo PluginsInfo {
            get => Singleton<IPluginsInfo>.Instance;
            set => Singleton<IPluginsInfo>.Instance = value;
        }

        /// <summary>
        /// 初始化插件
        /// </summary>
        /// <param name="applicationPartManager"></param>
        /// <param name="nopConfig"></param>
        public static void InitializePlugins(this ApplicationPartManager applicationPartManager, NopConfig config)
        {
            if (applicationPartManager == null)
                throw new ArgumentNullException(nameof(applicationPartManager));

            if (config == null)
                throw new ArgumentNullException(nameof(config));
            LoadPluginsInfo(config);

            using (new ReaderWriteLockDisposable(_locker))
            {
                var pluginDescriptors = new List<PluginDescriptor>();
                var incompatiblePlugins = new List<string>();

                try
                {
                    var pluginsDirectory = _fileProvider.MapPath(SniperPluginDefaults.Path);
                    _fileProvider.CreateDirectory(pluginsDirectory);

                    var shadowCopyDirectory = _fileProvider.MapPath(SniperPluginDefaults.ShadowCopyPath);
                    _fileProvider.CreateDirectory(shadowCopyDirectory);

                    var binFiles = _fileProvider.GetFiles(shadowCopyDirectory, "*", false);

                    if (config.ClearPluginShadowDirectoryOnStartup)
                    {
                        var placeholderFileNames = new List<string> { "placeholder.txt", "index.htm" };

                        binFiles = binFiles.Where(file =>
                        {
                            var fileName = _fileProvider.GetFileName(file);
                            return !placeholderFileNames.Any(placeholderFileName => placeholderFileName
                                .Equals(fileName, StringComparison.InvariantCultureIgnoreCase));
                        }).ToArray();

                        foreach (var file in binFiles)
                        {
                            try
                            {
                                _fileProvider.DeleteFile(file);
                            }
                            catch 
                            {

                            }
                        }

                        var reserveDirectories = _fileProvider.GetDirectories(shadowCopyDirectory, SniperPluginDefaults.ReserveShadowCopyPathNamePattern);

                        foreach (var directory in reserveDirectories)
                        {
                            try
                            {
                                _fileProvider.DeleteDirectory(directory);
                            }
                            catch
                            {

                            }
                        }

                        foreach (var item in GetDescriptionFilesAndDescriptors(pluginsDirectory))
                        {
                            var descriptionFile = item.DescriptionFile;
                            var pluginDescriptor = item.PluginDescriptor;

                            if (!pluginDescriptor.SupportedVersions.Contains(NopVersion.CurrentVersion, StringComparer.InvariantCultureIgnoreCase))
                            {
                                incompatiblePlugins.Add(pluginDescriptor.SystemName);
                                continue;
                            }

                            if (string.IsNullOrEmpty(pluginDescriptor.SystemName?.Trim()))
                            {
                                throw new Exception($"A plugin '{descriptionFile}' has no system name. Try assigning the plugin a unique name and recompiling.");
                            }

                            if (pluginDescriptors.Contains(pluginDescriptor))
                                throw new Exception($"A plugin with '{pluginDescriptor.SystemName}' system name is already defined");

                            pluginDescriptor.Installed = PluginsInfo.InstalledPluginNames
                                .Any(pluginName => pluginName.Equals(pluginDescriptor.SystemName, StringComparison.InvariantCultureIgnoreCase));

                            try
                            {
                                var pluginDirectory = _fileProvider.GetDirectoryName(descriptionFile);
                                if (string.IsNullOrEmpty(pluginsDirectory))
                                {
                                    throw new Exception($"Directory cannot be resolved for '{_fileProvider.GetFileName(descriptionFile)}' description file");
                                }

                                var pluginFiles = _fileProvider.GetFiles(pluginsDirectory, "*.dll", false)
                                    .Where(file => !binFiles.Contains(file) && IsPluginDirectory(_fileProvider.GetDirectoryName(file)))
                                    .ToList();

                                var mainPluginFile = pluginFiles.FirstOrDefault(file =>
                                {
                                    var fileName = _fileProvider.GetFileName(file);
                                    return fileName.Equals(pluginDescriptor.AssemblyFileName, StringComparison.InvariantCultureIgnoreCase);
                                });

                                if(mainPluginFile==null)
                                {
                                    incompatiblePlugins.Add(pluginDescriptor.SystemName);
                                    continue;
                                }

                                var pluginName = pluginDescriptor.SystemName;

                                pluginDescriptor.OriginalAssemblyFile = mainPluginFile;

                                var needToDeploy = PluginsInfo.InstalledPluginNames.Contains(pluginName);

                                needToDeploy = needToDeploy || PluginsInfo.PluginNamesToInstall.Any(pluginInfo => pluginInfo.SystemName.Equals(pluginName));

                                needToDeploy = needToDeploy && !PluginsInfo.PluginNamesToDelete.Contains(pluginName);

                                if (needToDeploy)
                                {
                                    pluginDescriptor.ReferencedAssembly = applicationPartManager.PerformFileDeploy(mainPluginFile, shadowCopyDirectory, config, _fileProvider);

                                    var filesToDeloy = pluginFiles.Where(file =>
                                     !_fileProvider.GetFileName(file).Equals(_fileProvider.GetFileName(mainPluginFile)) &&
                                     !IsAlreadyLoaded(file, pluginName)).ToList();

                                    foreach (var file in filesToDeloy)
                                    {
                                        applicationPartManager.PerformFileDeploy(file, shadowCopyDirectory, config, _fileProvider);
                                    }

                                    var pluginType = pluginDescriptor.ReferencedAssembly.GetTypes().FirstOrDefault(type => typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && type.IsClass && !type.IsAbstract);

                                    if (pluginType != default(Type))
                                        pluginDescriptor.PluginType = pluginType;


                                }

                                if (PluginsInfo.PluginNamesToDelete.Contains(pluginName))
                                {
                                    continue;
                                }

                                pluginDescriptors.Add(pluginDescriptor);
                            }
                            catch(ReflectionTypeLoadException exception)
                            {
                                var error = exception.LoaderExceptions.Aggregate($"Plugin '{pluginDescriptor.FriendlyName}'. ",
                              (message, nextMessage) => $"{message}{nextMessage.Message}{Environment.NewLine}");

                                throw new Exception(error, exception);
                            }
                            catch (Exception exception)
                            {
                                //add a plugin name, this way we can easily identify a problematic plugin
                                throw new Exception($"Plugin '{pluginDescriptor.FriendlyName}'. {exception.Message}", exception);
                            }
                        }

                    }
                }
                catch (Exception exception)
                {
                    var message = string.Empty;
                    for (var inner = exception; inner != null; inner = inner.InnerException)
                        message = $"{message}{inner.Message}{Environment.NewLine}";

                    throw new Exception(message, exception);
                }

                PluginsInfo.PluginDescriptors = pluginDescriptors;

                PluginsInfo.IncompatiblePlugins = incompatiblePlugins;

                PluginsInfo.AssemblyLoadedCollision = _loadedAssemblies.Select(item => item.Value)
                    .Where(loadedAssemblyInfo => loadedAssemblyInfo.Collisions.Any()).ToList();
            }


        }

        private static IList<(string DescriptionFile, PluginDescriptor PluginDescriptor)> GetDescriptionFilesAndDescriptors(string directoryName)
        {
            if(string.IsNullOrEmpty(directoryName))
                throw new ArgumentNullException(nameof(directoryName));

            var result= new List<(string DescriptionFile, PluginDescriptor PluginDescriptor)>();

            var files = _fileProvider.GetFiles(directoryName, SniperPluginDefaults.DescriptionFileName, false);

            foreach (var descriptionFile in files)
            {
                if (!IsPluginDirectory(_fileProvider.GetDirectoryName(descriptionFile)))
                    continue;

                var text = _fileProvider.ReadAllText(descriptionFile, Encoding.UTF8);

                var pluginDescriptor = PluginDescriptor.GetPluginDescriptorFromText(text);

                result.Add((descriptionFile, pluginDescriptor));


            }

            result = result.OrderBy(item => item.PluginDescriptor.Description).ToList();

            return result;
        }

        /// <summary>
        /// 判定时否为插件路径
        /// </summary>
        /// <param name="direcoryName"></param>
        /// <returns></returns>
        private static bool IsPluginDirectory(string direcoryName)
        {
            if (string.IsNullOrEmpty(direcoryName))
                return false;

            var parent = _fileProvider.GetParentDirectory(direcoryName);

            if (string.IsNullOrEmpty(parent))
                return false;
            if (!_fileProvider.GetDirectoryNameOnly(parent).Equals(SniperPluginDefaults.PathName, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///加载插件信息
        /// </summary>
        /// <param name="nopConfig"></param>
        private static void LoadPluginsInfo(NopConfig config)
        {
            var useRedisToStorePluginsInfo = config.RedisEnabled && config.UseRedisToStorePluginsInfo;

            PluginsInfo = useRedisToStorePluginsInfo ? new RedisPluginsInfo(_fileProvider, new RedisConnectionWrapper(config), config) : new PluginsInfo(_fileProvider);

            if (PluginsInfo.LoadPluginInfo() || useRedisToStorePluginsInfo || !config.RedisEnabled)
                return;

            var redisPluginsInfo = new RedisPluginsInfo(_fileProvider, new RedisConnectionWrapper(config), config);

            if (!redisPluginsInfo.LoadPluginInfo())
                return;

            PluginsInfo.CopyFrom(redisPluginsInfo);
            PluginsInfo.Save();

            redisPluginsInfo = new RedisPluginsInfo(_fileProvider, new RedisConnectionWrapper(config), config);
            redisPluginsInfo.Save();
        }

        /// <summary>
        /// 部署执行文件，返回程序集
        /// </summary>
        /// <param name="applicationPartManager"></param>
        /// <param name="assemblyFile"></param>
        /// <param name="shadowCopyDirectory"></param>
        /// <param name="config"></param>
        /// <param name="fileProvider"></param>
        /// <returns></returns>
        private static Assembly PerformFileDeploy(this ApplicationPartManager applicationPartManager, string assemblyFile, string shadowCopyDirectory, NopConfig config, INopFileProvider fileProvider)
        {
            if (string.IsNullOrEmpty(assemblyFile) || string.IsNullOrEmpty(fileProvider.GetParentDirectory(assemblyFile)))
            {
                throw new InvalidOperationException($"The plugin directory for the {fileProvider.GetFileName(assemblyFile)} file exists in a directory outside of the allowed nopCommerce directory hierarchy");
            }

            if (!config.UsePluginsShadowCopy)
            {
                var assembly = AddApplicationParts(applicationPartManager, assemblyFile, config.UseUnsafeLoadAssembly);

                if (assemblyFile.EndsWith(".dll"))
                {
                    _fileProvider.DeleteFile(assemblyFile.Substring(0, assemblyFile.Length - 4) + ".deps.json");
                }

                return assembly;
            }

            fileProvider.CreateDirectory(shadowCopyDirectory);

            var shadowCopiedFile = ShadowCopyFile(fileProvider, assemblyFile, shadowCopyDirectory);

            Assembly shadowCopiedAssembly = null;

            try
            {
                shadowCopiedAssembly = AddApplicationParts(applicationPartManager, shadowCopiedFile, config.UseUnsafeLoadAssembly);
            }
            catch (UnauthorizedAccessException)
            {
                if (!config.CopyLockedPluginAssembilesToSubdirectoriesOnStartup || !shadowCopyDirectory.Equals(fileProvider.MapPath(SniperPluginDefaults.ShadowCopyPath)))
                {
                    throw;
                }
            }
            catch (FileLoadException)
            {
                if (!config.CopyLockedPluginAssembilesToSubdirectoriesOnStartup ||
                   !shadowCopyDirectory.Equals(fileProvider.MapPath(SniperPluginDefaults.ShadowCopyPath)))
                {
                    throw;
                }
            }

            if (shadowCopiedAssembly != null)
            {
                return shadowCopiedAssembly;
            }

            var reserveDirectory = fileProvider.Combine(fileProvider.MapPath(SniperPluginDefaults.ShadowCopyPath),
            $"{SniperPluginDefaults.ReserveShadowCopyPathName}{DateTime.Now.ToFileTimeUtc()}");

            return PerformFileDeploy(applicationPartManager, assemblyFile, reserveDirectory, config, fileProvider);
        }

        /// <summary>
        /// 加载和注册程序集
        /// </summary>
        /// <param name="applicationPartManager"></param>
        /// <param name="assemblyFile"></param>
        /// <param name="useUnsafeLoadAssembly"></param>
        /// <returns></returns>
        private static Assembly AddApplicationParts(ApplicationPartManager applicationPartManager, string assemblyFile, bool useUnsafeLoadAssembly)
        {
            Assembly assembly;

            try
            {
                assembly = Assembly.LoadFrom(assemblyFile);
            }
            catch (FileLoadException)
            {
                if (useUnsafeLoadAssembly)
                {
                    assembly = Assembly.UnsafeLoadFrom(assemblyFile);
                }
                else
                {
                    throw;
                }
            }

            applicationPartManager.ApplicationParts.Add(new AssemblyPart(assembly));

            return assembly;
        }

        /// <summary>
        /// 复制插件程序集到Shadow目录
        /// </summary>
        /// <param name="fileProvider"></param>
        /// <param name="assemblyFile"></param>
        /// <param name="shadowCopyDirectory"></param>
        /// <returns></returns>
        private static string ShadowCopyFile(INopFileProvider fileProvider, string assemblyFile, string shadowCopyDirectory)
        {
            var shadowCopiedFile= fileProvider.Combine(shadowCopyDirectory, fileProvider.GetFileName(assemblyFile));

            if (fileProvider.FileExists(shadowCopiedFile))
            {
                var areFilesIdentical = fileProvider.GetCreationTime(shadowCopiedFile).ToUniversalTime().Ticks >= fileProvider.GetCreationTime(assemblyFile).ToUniversalTime().Ticks;
                if (areFilesIdentical)
                {
                    return shadowCopiedFile;
                }

                fileProvider.DeleteFile(shadowCopiedFile);
            }

            try
            {
                fileProvider.FileCopy(assemblyFile, shadowCopiedFile, true);
            }
            catch(IOException)
            {

                try
                {
                    var oldFile = $"{shadowCopiedFile}{Guid.NewGuid():N}.old";
                    fileProvider.FileMove(shadowCopiedFile, oldFile);
                }
                catch (IOException exception)
                {
                    throw new IOException($"{shadowCopiedFile} rename failed, cannot initialize plugin", exception);
                }

                fileProvider.FileCopy(assemblyFile, shadowCopiedFile, true);
            }

            return shadowCopiedFile;
        }

        /// <summary>
        /// 检测程序集是否加载
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="pluginName"></param>
        /// <returns></returns>
        private static bool IsAlreadyLoaded(string filePath, string pluginName)
        {
            var fileName = _fileProvider.GetFileName(filePath);

            if (_baseAppLibraries.Any(library => library.Equals(fileName, StringComparison.InvariantCultureIgnoreCase)))
            {
                return true;
            }

            try
            {
                var fileNameWithoutExtension = _fileProvider.GetFileNameWithoutExtension(filePath);

                if (string.IsNullOrEmpty(fileNameWithoutExtension))
                    throw new Exception($"Cannot get file extension for {fileName}");

                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                {
                    var assemblyName = assembly.FullName.Split(',').FirstOrDefault();
                    if (!fileNameWithoutExtension.Equals(assemblyName, StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    if (!_loadedAssemblies.ContainsKey(assemblyName))
                    {
                        _loadedAssemblies.Add(assemblyName, new PluginLoadedAssemblyInfo(assemblyName, assembly.FullName));

                    }

                    _loadedAssemblies[assemblyName].References.Add((pluginName, AssemblyName.GetAssemblyName(fileName).FullName));

                    return true;
                }
            }
            catch
            {

            }
            return false;
        }     

    }
}
