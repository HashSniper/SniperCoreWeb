using Newtonsoft.Json;
using Sniper.Services.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Themes
{
    public class ThemeDescriptor : IDescriptor
    {
        /// <summary>
        /// 系统名称
        /// </summary>
        [JsonProperty(PropertyName = "SystemName")]
        public string SystemName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "FriendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// 该值指示主题是否支持RTL（从右到左）
        /// </summary>
        [JsonProperty(PropertyName = "SupportRTL")]
        public bool SupportRtl { get; set; }

        /// <summary>
        /// 获取或设置主题预览图像的路径
        /// </summary>
        [JsonProperty(PropertyName = "PreviewImageUrl")]
        public string PreviewImageUrl { get; set; }

        /// <summary>
        /// 获取或设置主题的预览文本
        /// </summary>
        [JsonProperty(PropertyName = "PreviewText")]
        public string PreviewText { get; set; }

    }
}
