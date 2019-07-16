using Sniper.Core.Domain.Directory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Common
{
    public partial class Address : BaseEntity, ICloneable
    {
        /// <summary>
        /// 第一名称
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 国家编号
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// 州/省标识符
        /// </summary>
        public int? StateProvinceId { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 传真
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        /// 自定义标签
        /// </summary>
        public string CustomAttributes { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// 省份地区
        /// </summary>
        public virtual StateProvince StateProvince { get; set; }

        /// <summary>
        /// clone
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var addr = new Address
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Company = Company,
                Country = Country,
                CountryId = CountryId,
                StateProvince = StateProvince,
                StateProvinceId = StateProvinceId,
                County = County,
                City = City,
                Address1 = Address1,
                Address2 = Address2,
                ZipPostalCode = ZipPostalCode,
                PhoneNumber = PhoneNumber,
                FaxNumber = FaxNumber,
                CustomAttributes = CustomAttributes,
                CreatedOnUtc = CreatedOnUtc
            };

            return addr;
        }
    }
}
