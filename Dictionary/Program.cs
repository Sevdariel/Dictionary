using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Dictionary.Modules;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<MyDictionaryModule>();
            var container = builder.Build();

            var dict = container.Resolve<MyDictionary>();

            dict.Show();
            dict.Add();
            dict.Show();

        }
    }
}
