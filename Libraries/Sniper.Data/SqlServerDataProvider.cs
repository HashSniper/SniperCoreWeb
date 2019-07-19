using Sniper.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Sniper.Data
{
    public partial class SqlServerDataProvider : IDataProvider
    {
        /// <summary>
        /// 此数据提供程序是否支持备份
        /// </summary>
        public virtual bool BackupSupported => true;

        /// <summary>
        /// 获取HASHBYTES函数的最大数据长度，如果不支持HASHBYTES函数，则返回0
        /// </summary>
        public virtual int SupportedLengthOfBinaryHash => 8000; //for SQL Server 2008 and above HASHBYTES function has a limit of 8000 characters.

        #region
        public DbParameter GetParameter()
        {
            throw new NotImplementedException();
        }

        public void InitializeDatabase()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
