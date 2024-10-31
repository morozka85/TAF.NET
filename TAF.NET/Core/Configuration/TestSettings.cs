using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF.Core.Configuration
{
    public class TestSettings
    {
        public string BaseUrl { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string BrowserType { get; set; }
        public int TimeoutDefault { get; set; }
    }
}
