using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Sniper.Core.Data
{
    /*
     * 表示数据提供者
     */
    public partial interface IDataProvider
    {
        #region Methods

        /// <summary>
        /// 初始化数据库
        /// </summary>
        void InitializeDatabase();

        /// <summary>
        /// 获取支持数据库参数对象（由存储过程使用）
        /// </summary>
        /// <returns>Parameter</returns>
        DbParameter GetParameter();

        #endregion

        #region Properties

        /// <summary>
        /// 此数据提供程序是否支持备份
        /// </summary>
        bool BackupSupported { get; }

        /// <summary>
        /// 获取HASHBYTES函数的最大数据长度，如果不支持HASHBYTES函数，则返回0
        /// </summary>
        int SupportedLengthOfBinaryHash { get; }

        #endregion
    }
}
