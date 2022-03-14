using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Blogs;

namespace Simple.Abp.CmsKit.Public
{
    public class BlogPublicAppService : SimpleCmsKitPublicAppServiceBase, IBlogPublicAppService
    {
        protected IBlogRepository BlogRepository { get; }
        public BlogPublicAppService(IBlogRepository blogRepository)
        {
            BlogRepository = blogRepository;
        }

        public async Task<List<BlogDto>> GetAllAsync()
        {
            var blogs = await BlogRepository.GetListAsync();
            var modelList = ObjectMapper.Map<List<Blog>, List<BlogDto>>(blogs);
            return modelList;
        }
    }
}
