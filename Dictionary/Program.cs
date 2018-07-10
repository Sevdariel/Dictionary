using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Dictionary.Modules;
using Console = System.Console;

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
            var prepare = container.Resolve<DataPrepare>();
            bool loop = true;
            prepare.Load();
            while (loop)
            {
                Console.WriteLine("Co chcesz zrobic");
                Console.WriteLine("\tWyswietlic slownik (s),\n\tdodac nowe znaczenie (d),\n\tedytowac juz istniejace (e),\n\tznalezc juz istniejace (z),\n\twyjsc (w)\n");
                string key = Console.ReadLine().ToLower();
                switch (key)
                {
                    case "s":
                        dict.Show();
                        break;
                    case "d":
                        dict.Add();
                        break;
                    case "e":
                        dict.Edit();
                        break;
                    case "z":
                        dict.Find();
                        break;
                    case "w":
                        loop = false;
                        break;
                }
            }
        }
    }
}
