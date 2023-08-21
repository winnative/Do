using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace melakify.Behind.ML
{
    class ML3
    {
        List<(string key, List<string> words)> groups = new List<(string key, List<string> sens)>();
        public void Train(List<(string,string)> items)
        {
            var item = from i in items
                       group i by i.Item2 into i2
                       from i3 in i2
                       select new { Key = i2.Key, Values = i3.Item1 };

            List<string> word = new List<string>();

            
        }

        public static T Mode<T>(T[] list)
        {
            T mode = list.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

            return mode;
        }
    }
}
