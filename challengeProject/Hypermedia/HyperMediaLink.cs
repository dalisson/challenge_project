using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challengeProject.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { href = value; }
        }
        public string Type { get; set;  }
        public string Action { get; set; }
        public string Href { get; set; }
        public string href;
    }
}
