using Simple.Abp.CmsKit.Public.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Blogs;
using Volo.CmsKit.Public.Blogs;
using Volo.CmsKit.Tags;

namespace Simple.Abp.CmsKit.Public
{
    public class SimpleBlogPostPublicAppService : SimpleCmsKitPublicAppServiceBase, ISimpleBlogPostPublicAppService
    {
        protected IBlogRepository BlogRepository { get; }

        protected IBlogPostRepository BlogPostRepository { get; }

        private IRepository<BlogPost> _blogPostRepository;

        private IRepository<EntityTag> _entityTagRepository;

        private IRepository<Tag> _tagRepository;

        public SimpleBlogPostPublicAppService(IBlogRepository blogRepository,
            IBlogPostRepository blogPostRepository,
            IRepository<BlogPost> __blogPostRepository,
            IRepository<EntityTag> entityTagRepository,
            IRepository<Tag> tagRepository)
        {
            BlogRepository = blogRepository;
            BlogPostRepository = blogPostRepository;
            _blogPostRepository = __blogPostRepository;
            _entityTagRepository = entityTagRepository;
            _tagRepository = tagRepository;
        }

        public async Task<SimpleBlogPostDto> GetAsync(string blogSlug, string blogPostSlug)
        {
            var blog = await BlogRepository.GetBySlugAsync(blogSlug);
            var blogPost = await BlogPostRepository.GetBySlugAsync(blog.Id, blogPostSlug);

            var blogModel = ObjectMapper.Map<Blog, BlogDto>(blog);
            var model = ObjectMapper.Map<BlogPost, SimpleBlogPostDto>(blogPost);
            model.Blog = blogModel;

            // tags
            var entityId = blogPost.Id.ToString();
            var entityTagsQuery = await _entityTagRepository.GetQueryableAsync();
            var tagsQuery = await _tagRepository.GetQueryableAsync();
            var tags = from entityTag in entityTagsQuery
                       join tag in tagsQuery on entityTag.TagId equals tag.Id
                       select tag;
            model.Tags = ObjectMapper.Map<List<Tag>, List<TagDto>>(await AsyncExecuter.ToListAsync(tags));

            // 上一篇
            var query = await _blogPostRepository.WithDetailsAsync();
            var previousQuery = query.Where(c => c.CreationTime > blogPost.CreationTime && c.BlogId == blog.Id)
                    .OrderBy(c => c.CreationTime);

            var previousEntity = await AsyncExecuter.FirstOrDefaultAsync(previousQuery);
            model.Previous = ObjectMapper.Map<BlogPost, BlogPostPublicDto>(previousEntity);

            // 下一篇
            var nextQuery = query.Where(c => c.CreationTime < blogPost.CreationTime && c.BlogId == blog.Id)
                .OrderByDescending(c => c.CreationTime);
            var nextEntity = await AsyncExecuter.FirstOrDefaultAsync(nextQuery);
            model.Next = ObjectMapper.Map<BlogPost, BlogPostPublicDto>(nextEntity);

            return model;
        }

        public async Task<PagedResultDto<SimpleBlogPostDto>> GetListAsync(string blogSlug, SimpleBlogPostGetListInput input)
        {

            var blog = await BlogRepository.GetBySlugAsync(blogSlug);

            var blogPosts = await BlogPostRepository.GetListAsync(input.Filter, blog.Id, input.MaxResultCount, input.SkipCount, input.Sorting);
            var count = await BlogPostRepository.GetCountAsync(input.Filter, blog.Id);
            var modelList = ObjectMapper.Map<List<BlogPost>, List<SimpleBlogPostDto>>(blogPosts);

            return new PagedResultDto<SimpleBlogPostDto>(count, modelList);
        }
    }
}