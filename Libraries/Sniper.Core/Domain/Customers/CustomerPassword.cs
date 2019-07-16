using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Customers
{
    public partial class CustomerPassword : BaseEntity
    {
        public CustomerPassword()
        {
            PasswordFormat = PasswordFormat.Clear;
        }

        /// <summary>
        /// 客户id
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 密码格式标识符
        /// </summary>
        public int PasswordFormatId { get; set; }

        /// <summary>
        /// 密码salt
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// 密码格式
        /// </summary>
        public PasswordFormat PasswordFormat
        {
            get => (PasswordFormat)PasswordFormatId;
            set => PasswordFormatId = (int)value;
        }

        /// <summary>
        /// 客户
        /// </summary>
        public virtual Customer Customer { get; set; }

    }
}
