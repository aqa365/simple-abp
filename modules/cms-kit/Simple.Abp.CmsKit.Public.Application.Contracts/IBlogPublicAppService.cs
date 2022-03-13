using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.CmsKit.Admin.Blogs;

namespace Simple.Abp.CmsKit.Public
{
    public interface IBlogPublicAppService
    {
        Task<List<BlogDto>> GetAllAsync();
    }
}
