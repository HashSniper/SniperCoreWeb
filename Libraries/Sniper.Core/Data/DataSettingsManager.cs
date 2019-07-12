using Newtonsoft.Json;
using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sniper.Core.Data
{
    public partial class DataSettingsManager
    {
        #region Fileds
        private static bool? _databaseIsInstalled;
        #endregion
        /// <summary>
        /// 记载数据设置
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="reloadSettings"></param>
        /// <param name="nopFileProvider"></param>
        /// <returns></returns>
        public static DataSettings LoadSettings(string filePath = null, bool reloadSettings = false, INopFileProvider fileProvider = null)
        {
            if (!reloadSettings && Singleton<DataSettings>.Instace != null)
                return Singleton<DataSettings>.Instace;

            fileProvider = fileProvider ?? CommonHelper.DefaultFileProvider;
            filePath = filePath ?? fileProvider.MapPath(NopDataSettingsDefaults.FilePath);

            if (!fileProvider.FileExists(filePath))
            {
                filePath = fileProvider.MapPath(NopDataSettingsDefaults.ObsoleteFilePath);
                if (!fileProvider.FileExists(filePath))
                    return new DataSettings();

                var dataSettings = new DataSettings();

                using (var reader = new StringReader(fileProvider.ReadAllText(filePath, Encoding.UTF8)))
                {
                    string settingsLine;
                    while ((settingsLine = reader.ReadLine()) != null)
                    {
                        var separatorArr = settingsLine.Split(":");

                        if (separatorArr.Length <2)
                            continue;

                        var key = separatorArr[0].Trim();
                        var value = separatorArr[1].Trim();

                        switch (key)
                        {
                            case "DataProvider":
                                dataSettings.DataProvider = Enum.TryParse(value, true, out DataProviderType providerType) ? providerType : DataProviderType.Unknown;
                                continue;
                            case "DataConnectionString":
                                dataSettings.DataConnectionString = value;
                                continue;
                            default:
                                dataSettings.RawDataSettings[key] = value;
                                continue;
                        }
                    }
                }

                SaveSettings(dataSettings, fileProvider);
                fileProvider.DeleteFile(filePath);
                Singleton<DataSettings>.Instace = dataSettings;
                return Singleton<DataSettings>.Instace;
            }

            var text = fileProvider.ReadAllText(filePath, Encoding.UTF8);
            if (string.IsNullOrEmpty(text))
            {
                return new DataSettings();
            }

            Singleton<DataSettings>.Instace = JsonConvert.DeserializeObject<DataSettings>(text);

            return Singleton<DataSettings>.Instace;
        }

        /// <summary>
        /// 保存数据设置
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="fileProvider"></param>
        public static void SaveSettings(DataSettings settings, INopFileProvider fileProvider = null)
        {
            Singleton<DataSettings>.Instace=settings?? throw new ArgumentNullException(nameof(settings));

            fileProvider = fileProvider ?? CommonHelper.DefaultFileProvider;
            var filePath = fileProvider.MapPath(NopDataSettingsDefaults.FilePath);

            fileProvider.CreateFile(filePath);

            var text = JsonConvert.SerializeObject(Singleton<DataSettings>.Instace, Formatting.Indented);

            fileProvider.WriteAllText(filePath, text, Encoding.UTF8);
        }

        #region Properties

        public static bool DatabaseIsInstalled
        {
            get {
                if (!_databaseIsInstalled.HasValue)
                    _databaseIsInstalled = !string.IsNullOrEmpty(LoadSettings(reloadSettings: true)?.DataConnectionString);
                return _databaseIsInstalled.Value;

            }
        }


        #endregion

        #region Methods

        #endregion
    }
}
