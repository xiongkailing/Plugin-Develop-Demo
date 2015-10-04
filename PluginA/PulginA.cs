using Plugin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginA
{
    public class PulginA:IPluginTest
    {

        public void Dosomething()
        {
            Console.WriteLine("this word is from plugin A");
        }
    }
}
