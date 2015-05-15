using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozetkaTesting.Framework.DataModels
{
    public class SecondLevelItem
    {
        public string subTopic { get; set; }
        public string subUrl { get; set; }
        public ThirdLevelItem subSubItem { get; set; }
    }
}
