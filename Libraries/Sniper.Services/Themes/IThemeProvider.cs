using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Themes
{
    public partial interface IThemeProvider
    {
        /// <summary>
        /// 从描述文本中获取主题描述符
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        ThemeDescriptor GetThemeDescriptorFromText(string text);

        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        IList<ThemeDescriptor> GetThemes();

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="systemName"></param>
        /// <returns></returns>
        ThemeDescriptor GetThemeBySystemName(string systemName);

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="systemName"></param>
        /// <returns></returns>
        bool ThemeExists(string systemName);

    }
}
