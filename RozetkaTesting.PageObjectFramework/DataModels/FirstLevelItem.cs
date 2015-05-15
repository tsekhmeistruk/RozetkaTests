using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaTesting.Framework.DataModels
{
    public class FirstLevelItem
    {
        public string topic { get; set; }
        public string url { get; set; }
        public SecondLevelItem[] subItems { get; set; }
    }
}
