using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Abp.Account.Public.Web
{
    public class SimpleAccountPublicWebOptions
    {
        public string WebsiteFiling { get; set; }

        public string WebsiteFilingUrl { get; set; }

        public string WebInfo { get; set; }

        public string CdnHost { get; set; }

        public LoginPageOptions LoginPageOptions { get; set; }
    }

    public class LoginPageOptions
    {
        public string PageTitle { get; set; }

        public string MainTitle { get; set; }

        public string LogoUrl { get; set; }

    }
}
