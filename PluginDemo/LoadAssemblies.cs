using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace PluginDemo
{
    public class LoadAssemblies
    {
        public static string[] LoadPlugins(string direct)
        {
            List<string> ret = new List<string>();
            string[] files = Directory.GetFiles(direct);
            foreach(var file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Extension != ".dll")
                    continue;
                var assembly = Assembly.LoadFile(file);
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (type.GetInterface("IPluginTest", false) != null)
                    {
                        ret.Add(file);
                    }
                }
            }
            return ret.ToArray();
        }
    }
}
