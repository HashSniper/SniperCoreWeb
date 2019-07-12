using Sniper.Core.Configuration;
using Sniper.Core.Infrastructure;
using Sniper.Core.Redis;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Plugins
{
    public partial class RedisPluginsInfo:PluginsInfo
    {
        private readonly IDatabase _db;

        public RedisPluginsInfo(INopFileProvider fileProvider, IRedisConnectionWrapper connectionWrapper, NopConfig config)
            :base(fileProvider)
        {
            _db = connectionWrapper.GetDatabase(config.RedisDatabaseId ?? (int)RedisDatabaseNumber.Plugin);
        }
    }
}
