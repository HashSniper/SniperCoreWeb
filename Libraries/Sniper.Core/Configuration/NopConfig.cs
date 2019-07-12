using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Configuration
{
    /// <summary>
    ///网站配置相关
    /// </summary>
    public partial class NopConfig
    {
        /// <summary>
        /// 该值控制是否展示完整错误，在开发环境中一直启用
        /// </summary>
        public bool DisplayFullErrorStack { get; set; }

        /// <summary>
        /// Azure BLOB 存储连接字符串
        /// </summary>
        public string AzureBlobStorageConnectionString { get; set; }

        /// <summary>
        /// Azure BLOB 存储容器名
        /// </summary>
        public string AzureBlobStorageContainerName { get; set; }

        /// <summary>
        /// Azure BLOB 存储终结点
        /// </summary>
        public string AzureBlobStorageEndPoint { get; set; }

        /// <summary>
        /// 是否将容器名添加到AzureBlobStorageEndPoint
        /// </summary>
        public bool AzureBlobStorageAppendContainerName { get; set; }

        /// <summary>
        /// 是否启用Redis服务
        /// </summary>
        public bool RedisEnabled { get; set; }

        /// <summary>
        /// Redis连接字符串
        /// </summary>
        public string RedisConnectionString { get; set; }

        /// <summary>
        /// 设置一个 Redis 数据库
        /// </summary>
        public int? RedisDatabaseId { get; set; }

        /// <summary>
        /// 是否配置数据保护key
        /// </summary>
        public bool UseRedisToStoreDataProtectionKeys { get; set; }

        /// <summary>
        /// 是否将 Redis 设置缓存
        /// </summary>
        public bool UseRedisForCaching { get; set; }

        /// <summary>
        /// 是否使用 Redis 存储插件信息
        /// </summary>
        public bool UseRedisToStorePluginsInfo { get; set; }

        /// <summary>
        /// 使用代理数据库连接字符串
        /// </summary>
        public string UserAgentStringsPath { get; set; }

        /// <summary>
        /// 爬虫专用数据字符串
        /// </summary>
        public string CrawlerOnlyUserAgentStringsPath { get; set; }

        /// <summary>
        /// 安装期间是否可以安装数据
        /// </summary>
        public bool DisableSampleDataDuringInstallation { get; set; }

        /// <summary>
        /// 是否为快速安装
        /// </summary>
        public bool UseFastInstallationService { get; set; }

        /// <summary>
        /// 安装期间忽略的插件
        /// </summary>
        public string PluginsIgnoredDuringInstallation { get; set; }

        /// <summary>
        /// 值指示在应用程序启动时是否清除/plugins/bin目录
        /// </summary>
        public bool ClearPluginShadowDirectoryOnStartup { get; set; }

        /// <summary>
        /// 该值指示在应用程序启动时是否将“已锁定”程序集从/plugins/bin目录复制到临时子目录
        /// </summary>
        public bool CopyLockedPluginAssembilesToSubdirectoriesOnStartup { get; set; }

        /// <summary>
        /// 是否使用一些不安全的程序集
        /// </summary>
        public bool UseUnsafeLoadAssembly { get; set; }

        /// <summary>
        /// 值指示在应用程序启动时是否将插件库复制到/plugins/bin目录
        /// </summary>
        public bool UsePluginsShadowCopy { get; set; }

        /// <summary>
        /// sqlerver 2008 为true
        /// </summary>
        public bool UseRowNumberForPaging { get; set; }

        /// <summary>
        /// 是否将临时数据存储在sessions中
        /// </summary>
        public bool UseSessionStateTempDataProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool AzureBlobStorageEnabled => !string.IsNullOrEmpty(AzureBlobStorageConnectionString);

    }
}
