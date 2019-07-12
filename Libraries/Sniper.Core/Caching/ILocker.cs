using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Caching
{
    public interface ILocker
    {
        /// <summary>
        /// 使用独占模式进行某些操作
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="expirationTime"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        bool PerformActionWithLock(string resource, TimeSpan expirationTime, Action action);
        
    }
}
