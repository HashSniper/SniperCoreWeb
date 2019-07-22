using Autofac;
using Sniper.Core.Configuration;
using Sniper.Core.Infrastructure;
using Sniper.Core.Infrastructure.DependencyManagement;
using Sniper.Services.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sniper.Web.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 2;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<Factories.WidgetModelFactory>().As<Factories.IWidgetModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<WidgetPluginManager>().As<IWidgetPluginManager>().InstancePerLifetimeScope();
            builder.RegisterType<Factories.TopicModelFactory>().As<Factories.ITopicModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<Factories.CatalogModelFactory>().As<Factories.ICatalogModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<Factories.ProductModelFactory>().As<Factories.IProductModelFactory>().InstancePerLifetimeScope();


        }
    }
}
