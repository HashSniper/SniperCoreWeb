using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Domain.Common
{
    public class GenericAttribute
    {
        /// <summary>
        /// 实体id
        /// </summary>
        public int EntityId { get; set; }

        /// <summary>
        /// 密钥组
        /// </summary>
        public string KeyGroup { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 存储id
        /// </summary>
        public int StoreId { get; set; }


    }
}
