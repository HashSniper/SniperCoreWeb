using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.FileProviders.Physical;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Services.Media.RoxyFileman
{
    public class RoxyFilemanProvider : IFileProvider
    {
        #region Fileds
        private readonly PhysicalFileProvider _physicalFileProvider;
        #endregion

        #region Ctor

        public RoxyFilemanProvider(string root)
        {
            _physicalFileProvider = new PhysicalFileProvider(root);
        }

        public RoxyFilemanProvider(string root, ExclusionFilters filters)
        {
            _physicalFileProvider = new PhysicalFileProvider(root, filters);
        }
        #endregion

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            throw new NotImplementedException();
        }

        public IFileInfo GetFileInfo(string subpath)
        {
            throw new NotImplementedException();
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
