using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Abp.Articles
{
    public class ArticlesPermissions
    {
        public const string GroupName = "Articles";

        public class Articles
        {
            public const string Default = GroupName + ".Article";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
