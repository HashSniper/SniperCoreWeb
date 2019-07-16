using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sniper.Core.Infrastructure
{
    public class EngineContext
    {
        #region Merhods
        /// <summary>
        /// 创建Engine实例
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new NopEngine());

        }
        #endregion


        #region Properties
        public static IEngine Current
        {
            get {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }
        #endregion
    }
}
