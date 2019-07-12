using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sniper.Core.Infrastructure
{
    public class WebAppTypeFinder:AppDomainTypeFinder
    {
        #region Fileds
        private bool _binFolderAssembliesLoaded;
        #endregion

        #region Ctor

        #region Properties
        public bool EnsureBinFolderAssembliesLoaded { get; set; } = true;
        #endregion
        public WebAppTypeFinder(INopFileProvider fileProvider = null)
            : base(fileProvider)
        {

        }

        #endregion

        #region Methods

        public virtual string GetBinDirectory()
        {
            return AppContext.BaseDirectory;
        }

        public override IList<Assembly> GetAssemblies()
        {
            if (!EnsureBinFolderAssembliesLoaded||_binFolderAssembliesLoaded)
            return base.GetAssemblies();
            _binFolderAssembliesLoaded = true;
            var binPath = GetBinDirectory();

            LoadMatchingAssemblies(binPath);
            return base.GetAssemblies();
        }

        #endregion
    }
}
