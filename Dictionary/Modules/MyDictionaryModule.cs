using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Dictionary.Modules
{
    public class MyDictionaryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(MyDictionaryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterType<DataPrepare>().As<IDataPrepare>().InstancePerLifetimeScope();
            builder.RegisterType<MyDictionary>().As<IMyDictionary>().InstancePerLifetimeScope();
            builder.RegisterType<WordDictionary>().As<IWordDictionary>().InstancePerLifetimeScope();
        }
    }
}
