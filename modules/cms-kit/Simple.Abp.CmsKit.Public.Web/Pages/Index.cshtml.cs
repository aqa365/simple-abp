using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Simple.Abp.Articles.Public.Web.Pages
{
    public class IndexModel : AbpPageModel
    {
        private readonly IArticleAppService _articleAppService;

        /// <summary>
        ///  articles
        /// </summary>
        public List<ArticleDto> Articles { get; set; }

        /// <summary>
        /// bilibili
        /// </summary>
        public List<ArticleDto> Videos { get; set; }

        /// <summary>
        /// projects
        /// </summary>
        public List<ArticleDto> Projects { get; set; }


        public IndexModel(IArticleAppService articleAppService) 
        {
            _articleAppService = articleAppService;
            Articles = new List<ArticleDto>();
            Videos = new List<ArticleDto>();
            Projects = new List<ArticleDto>();
        }

        private ArticlePagedRequestDto CreateDefaultSearchInput()
        {
            ArticlePagedRequestDto input = new ArticlePagedRequestDto();
            input.MaxResultCount = 5;
            return input;
        }

        private async Task InitArticles()
        {
            var input = CreateDefaultSearchInput();
            var pageResult = await _articleAppService.GetDefaultListAsync(input);
            if (pageResult.Items != null && pageResult.Items.Count > 0)
                Articles = pageResult.Items.ToList();
        }

        private async Task InitVideos()
        {
            var input = CreateDefaultSearchInput();
            input.CatalogTitle = "bilibili";
            var pageResult = await _articleAppService.GetDefaultListAsync(input);
            if (pageResult.Items != null && pageResult.Items.Count > 0)
                Videos = pageResult.Items.ToList();
        }

        private async Task InitProjects()
        {
            var input = CreateDefaultSearchInput();
            input.CatalogTitle = "projects";
            var pageResult = await _articleAppService.GetDefaultListAsync(input);
            if (pageResult.Items != null && pageResult.Items.Count > 0)
                Projects = pageResult.Items.ToList();
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(InitArticles());
            tasks.Add(InitVideos());
            tasks.Add(InitProjects());
            await Task.WhenAll(tasks);

            return Page();
        }
    }
}
