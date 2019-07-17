using Sniper.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace Sniper.Core
{
    public partial class CommonHelper
    {
        public static INopFileProvider DefaultFileProvider { get; set; }

        /// <summary>
        /// 将值转换为目标类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(object value)
        {
            return (T)To(value, typeof(T));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <returns></returns>
        public static object To(object value, Type destinationType)
        {
            return To(value, destinationType, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="destinationType"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public static object To(object value, Type destinationType, CultureInfo culture)
        {
            if (value == null)
                return null;

            var sourceType = value.GetType();

            var destinationConverter = TypeDescriptor.GetConverter(destinationType);
            if (destinationConverter.CanConvertFrom(value.GetType()))
            {
                return destinationConverter.ConvertFrom(null, culture, value);
            }

            var sourceConverter = TypeDescriptor.GetConverter(sourceType);

            if (sourceConverter.CanConvertFrom(destinationType))
            {
                return sourceConverter.ConvertTo(null, culture, value, destinationType);
            }

            if (destinationType.IsEnum && value is int)
            {
                return Enum.ToObject(destinationType, (int)value);
            }

            if (!destinationType.IsInstanceOfType(value))
            {
                return Convert.ChangeType(value, destinationType, culture);
            }

            return value;
        }


        public static void SetTelerikCulture()
        {
            var culture = new CultureInfo("en-US");
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
    }
}
