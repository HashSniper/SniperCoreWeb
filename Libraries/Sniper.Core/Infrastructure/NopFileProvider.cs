using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;

namespace Sniper.Core.Infrastructure
{
    public class NopFileProvider : PhysicalFileProvider, INopFileProvider
    {
        public NopFileProvider(IHostingEnvironment hostingEnvironment)
            : base(File.Exists(hostingEnvironment.WebRootPath) ? Path.GetDirectoryName(hostingEnvironment.WebRootPath) : hostingEnvironment.WebRootPath)
        {
            var path = hostingEnvironment.ContentRootPath ?? string.Empty;
            if (File.Exists(path))
                path = Path.GetDirectoryName(path);

            BaseDirectory = path;
        }

        protected string BaseDirectory { get; }

        #region Methods
        public virtual string Combine(params string[] paths)
        {
            var path = Path.Combine(paths.SelectMany(p => IsUncPath(p) ? new[] { p } : p.Split('\\', '/')).ToArray());

            if (Environment.OSVersion.Platform == PlatformID.Unix && !IsUncPath(path))
                path = "/" + path;

            return path;
        }

        public virtual void CreateDirectory(string path)
        {
            if (!DirectoryExists(path))
                Directory.CreateDirectory(path);
        }

        public void CreateFile(string path)
        {
            if (FileExists(path))
                return;

            var fileInfo = new FileInfo(path);

            CreateDirectory(fileInfo.DirectoryName);

            using (File.Create(path))
            { }
        }

        public void DeleteDirectory(string path)
        {
            if(string.IsNullOrEmpty(path))
                throw new ArgumentNullException(path);

            foreach (var directory in Directory.GetDirectories(path))
            {
                DeleteDirectory(directory);
            }

            try
            {
                DeleteDirectoryRecursive(path);
            }
            catch (IOException)
            {
                DeleteDirectoryRecursive(path);
            }
            catch (UnauthorizedAccessException)
            {
                DeleteDirectoryRecursive(path);
            }
        }

        public virtual void DeleteFile(string filePath)
        {
            if (!FileExists(filePath))
                return;
            File.Delete(filePath);
        }

        public virtual bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public virtual void DirectoryMove(string sourceDirName, string destDirName)
        {
            Directory.Move(sourceDirName, destDirName);
        }

        public virtual IEnumerable<string> EnumerateFiles(string directoryPath, string searchPattern, bool topDirectoryOnly = true)
        {
            return Directory.EnumerateFiles(directoryPath, searchPattern, topDirectoryOnly ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories);
        }

        public virtual void FileCopy(string sourceFileName, string destFileName, bool overwrite = false)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }

        public virtual bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public virtual long FileLength(string path)
        {
            if (!FileExists(path))
                return -1;
            return new FileInfo(path).Length;
        }

        public virtual void FileMove(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }

        public virtual string GetAbsolutePath(params string[] paths)
        {
            var allPaths = new List<string> { Root };

            allPaths.AddRange(paths);

            return Combine(allPaths.ToArray());
        }

        public virtual DirectorySecurity GetAccessControl(string path)
        {
            return new DirectoryInfo(path).GetAccessControl();
        }

        public virtual DateTime GetCreationTime(string path)
        {
            return File.GetCreationTime(path);
        }

        public virtual string[] GetDirectories(string path, string searchPattern = "", bool topDirectoryOnly = true)
        {
            if (string.IsNullOrEmpty(searchPattern))
                searchPattern = "*";
            return Directory.GetDirectories(path, searchPattern, topDirectoryOnly ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories);
        }

        public virtual string GetDirectoryName(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public virtual string GetDirectoryNameOnly(string path)
        {
            return new DirectoryInfo(path).Name;
        }

        public virtual string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        public virtual string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public string GetFileNameWithoutExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public virtual string[] GetFiles(string directoryPath, string searchPattern = "", bool topDirectoryOnly = true)
        {
            if (string.IsNullOrEmpty(searchPattern))
                searchPattern = "*.*";

            return Directory.GetFiles(directoryPath, searchPattern,
                topDirectoryOnly ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories);
        }

        public DateTime GetLastAccessTime(string path)
        {
            return File.GetLastAccessTime(path);
        }

        public DateTime GetLastWriteTime(string path)
        {
            return File.GetLastWriteTime(path);
        }

        public DateTime GetLastWriteTimeUtc(string path)
        {
            return File.GetLastWriteTimeUtc(path);
        }

        public virtual string GetParentDirectory(string directoryPath)
        {
            return Directory.GetParent(directoryPath).FullName;
        }

        public virtual string GetVirtualPath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;

            if (!IsDirectory(path) && FileExists(path))
                path = new FileInfo(path).DirectoryName;

            path = path?.Replace(Root, "").Replace('\\', '/').Trim('/').TrimStart('~', '/');

            return $"~/{path ?? ""}";
        }

        public bool IsDirectory(string path)
        {
            return DirectoryExists(path);
        }

        public virtual string MapPath(string path)
        {
            path = path.Replace("~/", string.Empty).TrimStart('/');

            //if virtual path has slash on the end, it should be after transform the virtual path to physical path too
            var pathEnd = path.EndsWith('/') ? Path.DirectorySeparatorChar.ToString() : string.Empty;

            return Combine(BaseDirectory ?? string.Empty, path) + pathEnd;
        }

        public byte[] ReadAllBytes(string filePath)
        {
            return File.Exists(filePath) ? File.ReadAllBytes(filePath) : new byte[0];
        }

        public string ReadAllText(string path, Encoding encoding)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var streamReader = new StreamReader(fileStream, encoding))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc)
        {
            File.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
        }

        public void WriteAllBytes(string filePath, byte[] bytes)
        {
            File.WriteAllBytes(filePath, bytes);
        }

        public void WriteAllText(string path, string contents, Encoding encoding)
        {
            File.WriteAllText(path, contents, encoding);
        }
        #endregion

        #region Utilities

        /// <summary>
        /// 确定字符串为是否为通用命名规范
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected static bool IsUncPath(string path)
        {
            return Uri.TryCreate(path, UriKind.Absolute, out var uri) && uri.IsUnc;
        }


        private static void DeleteDirectoryRecursive(string path)
        {
            Directory.Delete(path, true);

            int maxIterationToWait = 10;

            var curIteration = 0;

            while (Directory.Exists(path))
            {
                curIteration++;
                if (curIteration > maxIterationToWait)
                    return;
                Thread.Sleep(100);
            }
        }

        #endregion
    }
}
