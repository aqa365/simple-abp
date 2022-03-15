using AutoMapper;
using Simple.Abp.CmsKit.Public.Dtos;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Blogs;

namespace Simple.Abp.CmsKit.Public
{
    public class SimpleCmsKitApplicationAutoMapperProfile : Profile
    {
        public SimpleCmsKitApplicationAutoMapperProfile()
        {
            CreateMap<Blog, BlogDto>();

            CreateMap<BlogPost, SimpleBlogPostDto>()
                .ForMember(c => c.Previous, c => c.Ignore())
                .ForMember(c => c.Next, c => c.Ignore())
                .ForMember(c => c.Blog, c => c.Ignore());
        }
    }
}
