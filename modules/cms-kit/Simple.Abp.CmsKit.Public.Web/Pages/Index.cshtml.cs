using Microsoft.AspNetCore.Mvc;
using Simple.Abp.CmsKit.Public.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.CmsKit.Admin.Blogs;
using Volo.CmsKit.Public.Blogs;

namespace Simple.Abp.CmsKit.Public.Web.Pages
{
    public class IndexModel : AbpPageModel
    {
        private readonly IBlogPublicAppService _blogPublicAppService;
        private readonly ISimpleBlogPostPublicAppService _blogPostPublicAppService;

        /// <summary>
        ///  Blogs
        /// </summary>
        public List<BlogDto> Blogs { get; set; }

        /// <summary>
        /// BlogPosts
        /// </summary>
        public List<SimpleBlogPostDto> BlogPosts { get; set; }



        public IndexModel(IBlogPublicAppService blogPublicAppService, ISimpleBlogPostPublicAppService blogPostPublicAppService)
        {
            _blogPublicAppService = blogPublicAppService;
            _blogPostPublicAppService = blogPostPublicAppService;
            BlogPosts = new List<SimpleBlogPostDto>();
        }

        private SimpleBlogPostGetListInput CreateDefaultSearchInput()
        {
            SimpleBlogPostGetListInput request = new SimpleBlogPostGetListInput();
            request.SkipCount = 0;
            request.MaxResultCount = 5;
            return request;
        }

        private async Task InitBlogs()
        {
            Blogs = await _blogPublicAppService.GetAllAsync();
        }

        private async Task InitBlogPosts()
        {
            List<Task<PagedResultDto<SimpleBlogPostDto>>> tasks = new List<Task<PagedResultDto<SimpleBlogPostDto>>>();

            foreach (var blog in Blogs)
            {
                var input = this.CreateDefaultSearchInput();
                tasks.Add(
                    _blogPostPublicAppService.GetListAsync(blog.Slug, input)
                );
            }

            await Task.WhenAll(tasks);
            tasks.ForEach(task => BlogPosts.AddRange(task.Result.Items));
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            await InitBlogs();
            await InitBlogPosts();
            return Page();
        }
    }
}
