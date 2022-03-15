using Simple.Abp.CmsKit.Public.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Blogs;
using Volo.CmsKit.Public.Blogs;

namespace Simple.Abp.CmsKit.Public
{
    public class SimpleBlogPostPublicAppService : SimpleCmsKitPublicAppServiceBase, ISimpleBlogPostPublicAppService
    {
        protected IBlogRepository BlogRepository { get; }

        protected IBlogPostRepository BlogPostRepository { get; }

        private IRepository<BlogPost> _blogPostRepository;

        public SimpleBlogPostPublicAppService(IBlogRepository blogRepository,
            IBlogPostRepository blogPostRepository,
            IRepository<BlogPost> __blogPostRepository)
        {
            BlogRepository = blogRepository;
            BlogPostRepository = blogPostRepository;
            _blogPostRepository = __blogPostRepository;
        }

        public async Task<BlogPostPublicDto> GetPreviousAsync(Guid blogId, Guid blogPostId, DateTime creationTime)
        {
            var query = await _blogPostRepository.WithDetailsAsync();

            var previousQuery = query.Where( c =>
                                    c.Id != blogPostId &&
                                    c.BlogId == blogId &&
                                    c.CreationTime > creationTime                              
                                ).OrderBy(c => c.CreationTime);

            var previousEntity = await AsyncExecuter.FirstOrDefaultAsync(previousQuery);
            var previousDto = ObjectMapper.Map<BlogPost, BlogPostPublicDto>(previousEntity);
            return previousDto;
        }

        public async Task<BlogPostPublicDto> GetNextAsync(Guid blogId, Guid blogPostId, DateTime creationTime)
        {
            var query = await _blogPostRepository.WithDetailsAsync();
            var nextQuery = query.Where(c =>
                                c.BlogId == blogId &&
                                c.Id != blogPostId &&
                                c.CreationTime < creationTime
                            ).OrderByDescending(c => c.CreationTime);

            var nextEntity = await AsyncExecuter.FirstOrDefaultAsync(nextQuery);
            var nextDto = ObjectMapper.Map<BlogPost, BlogPostPublicDto>(nextEntity);
            return nextDto;
        }

        public async Task<SimpleBlogPostDto> GetAsync(string blogSlug, string blogPostSlug)
        {
            var blog = await BlogRepository.GetBySlugAsync(blogSlug);
            var blogDto = ObjectMapper.Map<Blog, BlogDto>(blog);

            var blogPost = await BlogPostRepository.GetBySlugAsync(blog.Id, blogPostSlug);
            var blogPostDto = ObjectMapper.Map<BlogPost, SimpleBlogPostDto>(blogPost);
            blogPostDto.Blog = blogDto;

            blogPostDto.Previous = await this.GetPreviousAsync(blog.Id, blogPost.Id, blogPost.CreationTime);
            blogPostDto.Next = await this.GetNextAsync(blog.Id, blogPost.Id, blogPost.CreationTime);

            return blogPostDto;
        }

        public async Task<PagedResultDto<SimpleBlogPostDto>> GetListAsync(string blogSlug, SimpleBlogPostGetListInput input)
        {
            var blog = await BlogRepository.GetBySlugAsync(blogSlug);

            var blogPosts = await BlogPostRepository.GetListAsync(input.Filter, blog.Id, input.MaxResultCount, input.SkipCount, input.Sorting);
            var count = await BlogPostRepository.GetCountAsync(input.Filter, blog.Id);

            var blogPostDtos = ObjectMapper.Map<List<BlogPost>, List<SimpleBlogPostDto>>(blogPosts);
            return new PagedResultDto<SimpleBlogPostDto>(count, blogPostDtos);
        }
    }
}