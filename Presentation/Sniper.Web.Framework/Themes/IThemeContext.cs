using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Web.Framework.Themes
{
    public interface IThemeContext
    {
        /// <summary>
        /// Get or set current theme system name
        /// </summary>
        string WorkingThemeName { get; set; }
    }
}
