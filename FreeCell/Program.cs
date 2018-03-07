using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCell
{
    class Program
    {
        static void Main(string[] args)
        {
            string perfJson = System.IO.File.ReadAllText("..\\..\\PerfFun.json");
            JArray perf = JArray.Parse(perfJson);

            string testJson = System.IO.File.ReadAllText("..\\..\\Fun.json");
            JArray test = JArray.Parse(testJson);

            foreach(var obj in perf)
            {

                Console.WriteLine(test.Contains(obj));
            }

            //Console.WriteLine(perf.Contains(test[0]));
            Console.WriteLine(perf[0]);

        }
    }
}
