using Autofac;
using Sniper.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sniper.Core.Infrastructure.DependencyManagement
{
    public interface IDependencyRegistrar
    {

        void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config);
        int Order { get; }

    }
}
