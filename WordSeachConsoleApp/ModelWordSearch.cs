using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSeachConsoleApp
{
    public class ModelWordSearch
    {
        public string textToSearch { get; set; }
        public string file { get; set; }
        public string folder { get; set; }
        public string uri { get; set; }
        public bool isRverseSearch { get; set; }
        public bool isCaseInSensitiveSearch { get; set; }
    }
}
