using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.SiteConfiguration
{
    public class SiteConfigs
    {

    }

    public class Rootobject
    {
        public Logging Logging { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public Siteconfig siteconfig { get; set; }
        public string AllowedHosts { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }

    public class Siteconfig
    {
        public int firstcommision { get; set; }
        public int secondcommision { get; set; }
        public int reachprice { get; set; }
    }


}
