using RedLockNet.SERedis;
using RedLockNet.SERedis.Configuration;
using Sniper.Core.Caching;
using Sniper.Core.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Sniper.Core.Redis
{
    public class RedisConnectionWrapper : IRedisConnectionWrapper, ILocker
    {
        #region Fileds
        private readonly NopConfig _config;

        private readonly object _lock = new object();
        private volatile ConnectionMultiplexer _connection;
        private readonly Lazy<string> _connectionString;
        private volatile RedLockFactory _redLockFactory;
        #endregion

        #region Ctor
        public RedisConnectionWrapper(NopConfig config)
        {
            _config = config;
            _connectionString = new Lazy<string>(GetConnectionString);
            _redLockFactory = CreateRedisLockFactory();
        }
        #endregion

        /// <summary>
        ///获取redis 连接字符串
        /// </summary>
        /// <returns></returns>
        protected string GetConnectionString()
        {
            return _config.RedisConnectionString;
        }

        /// <summary>
        /// 创建 RedLockFactory 实例
        /// </summary>
        /// <returns></returns>
        protected RedLockFactory CreateRedisLockFactory()
        {
           var configurationOptions = ConfigurationOptions.Parse(_connectionString.Value);
            var redLockEndPoints = GetEndPoints().Select(endPoint => new RedLockEndPoint
            {
                EndPoint = endPoint,
                Password = configurationOptions.Password,
                Ssl=configurationOptions.Ssl,
                RedisDatabase=configurationOptions.DefaultDatabase,
                ConfigCheckSeconds=configurationOptions.ConfigCheckSeconds,
                SyncTimeout=configurationOptions.SyncTimeout
            }).ToList();

            return RedLockFactory.Create(redLockEndPoints);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void FlushDatabase(RedisDatabaseNumber db)
        {
            throw new NotImplementedException();
        }

        public IDatabase GetDatabase(int db)
        {
            throw new NotImplementedException();
        }

        public EndPoint[] GetEndPoints()
        {
            throw new NotImplementedException();
        }

        public IServer GetServer(EndPoint endPoint)
        {
            throw new NotImplementedException();
        }

        public bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action)
        {
            throw new NotImplementedException();
        }
    }
}
