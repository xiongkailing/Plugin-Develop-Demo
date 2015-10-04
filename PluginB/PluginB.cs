
using Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginB
{
    public class PluginB:IPluginTest
    {

        public void Dosomething()
        {
            Console.WriteLine("this word is from Plugin B");
        }
    }
}
