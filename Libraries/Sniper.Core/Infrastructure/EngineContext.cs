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
            return Singleton<IEngine>.Instace ?? (Singleton<IEngine>.Instace = new NopEngine());

        }
        #endregion


        #region Properties
        public static IEngine Current
        {
            get {
                if (Singleton<IEngine>.Instace == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instace;
            }
        }
        #endregion
    }
}
