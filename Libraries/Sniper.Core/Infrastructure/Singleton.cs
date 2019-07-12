using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Infrastructure
{
    public class Singleton<T>:BaseSingleton
    {
        private static T instance;


        public static T Instace
        {
            get => instance;
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }
}
