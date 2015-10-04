using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Plugin.Interfaces;
using System.IO;

namespace PluginDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Choose Pulgin To DoSomething! input its index");
            string path = @"../../Plugins";
            string basic=Directory.GetCurrentDirectory();
            path = Path.Combine(basic, path);
            var files = LoadAssemblies.LoadPlugins(path);
            for (int i=0;i<files.Length;i++)
            {
                Console.WriteLine("{0} : {1}", i , files[i]);
            }
            int index = -1;
            while (true)
            {
                string temp = Console.ReadLine();               
                if (int.TryParse(temp,out index)) {
                    if (index < files.Length && index >= 0)
                        break;
                }
                Console.WriteLine("invalid input");
            }
            var assembly = Assembly.LoadFile(files[index]);
            var types = assembly.GetTypes();
            foreach (System.Type type in types)
            {
                if (type.GetInterface("IPluginTest",false) != null)
                {
                    IPluginTest plugin = (IPluginTest)Activator.CreateInstance(type);
                    plugin.Dosomething();
                }
            }
            Console.ReadLine();
        }
    }
}
