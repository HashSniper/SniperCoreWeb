using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Services.Plugins
{
    public partial class PluginLoadedAssemblyInfo
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="shortName"></param>
        /// <param name="assemblyInMemory"></param>
        public PluginLoadedAssemblyInfo(string shortName, string assemblyInMemory)
        {
            ShortName = shortName;
            References = new List<(string PluginName, string AssemblyName)>();
            AssemblyFullNameInMemory = assemblyInMemory;
        }

        #region Properties
        /// <summary>
        /// 程序集名称
        /// </summary>
        public string ShortName { get; }
        
        /// <summary>
        /// 程序集完整名称
        /// </summary>
        public string AssemblyFullNameInMemory { get; }

        /// <summary>
        /// 被引用
        /// </summary>
        public List<(string PluginName, string AssemblyName)> References { get; }

        /// <summary>
        /// 加载程序集的反射
        /// </summary>
        public IList<(string PluginName, string AssemblyName)> Collisions =>
            References.Where(references => !references.AssemblyName.Equals(AssemblyFullNameInMemory, StringComparison.CurrentCultureIgnoreCase)).ToList();
        #endregion
    }
}
