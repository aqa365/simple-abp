using Simple.Abp.CmsKit.Public.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Blogs;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public
{
    public class SimpleBlogPostPublicAppService : SimpleCmsKitPublicAppServiceBase, ISimpleBlogPostPublicAppService
    {
        protected IBlogRepository BlogRepository { get; }

        protected IBlogPostRepository BlogPostRepository { get; }

        private IRepository<Blog> _blogRepository;
        private IRepository<BlogPost> _blogPostRepository;
        private IRepository<EntityTag> _entityTagRepository;
        private ITagRepository _tagRepository;

        public SimpleBlogPostPublicAppService(IBlogRepository blogRepository,
            IRepository<Blog> __blogRepository,
            IBlogPostRepository blogPostRepository,
            IRepository<BlogPost> __blogPostRepository,
            IRepository<EntityTag> entityTagRepository,
            ITagRepository tagRepository)
        {
            BlogRepository = blogRepository;
            _blogRepository = __blogRepository;
            BlogPostRepository = blogPostRepository;
            _blogPostRepository = __blogPostRepository;
            _entityTagRepository = entityTagRepository;
            _tagRepository  = tagRepository;
        }

        public async Task<SimpleBlogPostDto?> GetPreviousAsync(Guid blogId, Guid blogPostId, DateTime creationTime)
        {
            var query = await _blogPostRepository.WithDetailsAsync();

            var previousQuery = query.Where( c =>
                                    c.Id != blogPostId &&
                                    c.BlogId == blogId &&
                                    c.CreationTime > creationTime                              
                                ).OrderBy(c => c.CreationTime);

            var previousEntity = await AsyncExecuter.FirstOrDefaultAsync(previousQuery);
            var previousDto = ObjectMapper.Map<BlogPost, SimpleBlogPostDto>(previousEntity);
            return previousDto;
        }

        public async Task<SimpleBlogPostDto?> GetNextAsync(Guid blogId, Guid blogPostId, DateTime creationTime)
        {
            var query = await _blogPostRepository.WithDetailsAsync();
            var nextQuery = query.Where(c =>
                                c.BlogId == blogId &&
                                c.Id != blogPostId &&
                                c.CreationTime < creationTime
                            ).OrderByDescending(c => c.CreationTime);

            var nextEntity = await AsyncExecuter.FirstOrDefaultAsync(nextQuery);
            var nextDto = ObjectMapper.Map<BlogPost, SimpleBlogPostDto>(nextEntity);
            return nextDto;
        }

        public async Task<SimpleBlogPostDto?> GetAsync(string blogSlug, string blogPostSlug)
        {
            var existBlogSlug = await BlogRepository.SlugExistsAsync(blogSlug);
            if (!existBlogSlug)
                return null;

            var blog = await BlogRepository.GetBySlugAsync(blogSlug);
            var blogDto = ObjectMapper.Map<Blog, BlogDto>(blog);

            var existBlogPostSlug = await BlogPostRepository.SlugExistsAsync(blog.Id, blogPostSlug);
            if (!existBlogPostSlug)
                return null;

            var blogPost = await BlogPostRepository.GetBySlugAsync(blog.Id, blogPostSlug);
            var blogPostDto = ObjectMapper.Map<BlogPost, SimpleBlogPostDto>(blogPost);
            blogPostDto.Blog = blogDto;

            blogPostDto.Previous = await this.GetPreviousAsync(blog.Id, blogPost.Id, blogPost.CreationTime);
            blogPostDto.Next = await this.GetNextAsync(blog.Id, blogPost.Id, blogPost.CreationTime);

            return blogPostDto;
        }

        public async Task<PagedResultDto<SimpleBlogPostDto>> GetListAsync(string blogSlug, SimpleBlogPostGetListInput input)
        {
            var pageResult = new PagedResultDto<SimpleBlogPostDto>(0, new List<SimpleBlogPostDto>());

            var existBlogSlug = await BlogRepository.SlugExistsAsync(blogSlug);
            if (!existBlogSlug)
                return pageResult; 

            var blog = await BlogRepository.GetBySlugAsync(blogSlug);
            var blogPosts = await BlogPostRepository.GetListAsync(input.Filter, blog.Id, input.MaxResultCount, input.SkipCount, input.Sorting);

            pageResult.TotalCount = await BlogPostRepository.GetCountAsync(input.Filter, blog.Id);
            pageResult.Items = ObjectMapper.Map<List<BlogPost>, List<SimpleBlogPostDto>>(blogPosts);
            return pageResult;
        }

        public async Task<PagedResultDto<SimpleBlogPostDto>> GetListByTagAsync(string tagName,SimpleBlogPostGetListInput input)
        {
            var pageResult = new PagedResultDto<SimpleBlogPostDto>(0, new List<SimpleBlogPostDto>());

            var tag = await _tagRepository.FindAsync("BlogPost", tagName);
            if (tag == null)
                return pageResult;

            var queryEntityTags = await _entityTagRepository.GetQueryableAsync();
            queryEntityTags = queryEntityTags.Where(c => c.TagId == tag.Id).Skip(input.SkipCount).Take(input.MaxResultCount);

            var blogPostIds = queryEntityTags.Select(c => c.EntityId).ToList();

            var blogPostQuery = await _blogPostRepository.GetQueryableAsync();
            var blogPosts = blogPostQuery.Where(c => blogPostIds.Contains(c.Id.ToString())).ToList();

            var blogQuery = await _blogRepository.GetQueryableAsync();
            var blogIds = blogPosts.Select(c => c.BlogId).ToList();
            var blogs = blogQuery.Where(c => blogIds.Contains(c.Id)).ToList();

            var blogPostDtos = ObjectMapper.Map<List<BlogPost>, List<SimpleBlogPostDto>>(blogPosts);
            blogPostDtos.ForEach(blogPost =>
            {
                var blog = blogs.First(blog => blog.Id == blogPost.BlogId);
                blogPost.Blog = ObjectMapper.Map<Blog, BlogDto>(blog);
            });

            pageResult.TotalCount = queryEntityTags.Count();
            pageResult.Items = blogPostDtos;
            return pageResult;
        }
    }
}