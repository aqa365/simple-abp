using AutoMapper;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Blogs;

namespace Simple.Abp.CmsKit.Public
{
    public class SimpleCmsKitApplicationAutoMapperProfile: Profile
    {
        public SimpleCmsKitApplicationAutoMapperProfile()
        {
            CreateMap<Blog, BlogDto>();
        }
    }
}
