using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Public.Blogs;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public.Dtos
{
    public class SimpleBlogPostDto:BlogPostPublicDto
    {
        public BlogPostPublicDto? Previous { get; set; }

        public BlogPostPublicDto? Next { get; set; }

        public BlogDto? Blog { get; set; }
    }
}
