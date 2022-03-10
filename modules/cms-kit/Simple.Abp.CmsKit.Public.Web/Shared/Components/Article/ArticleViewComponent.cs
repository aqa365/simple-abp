using Microsoft.AspNetCore.Mvc;
using Simple.Abp.Articles.Dtos;
using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc;

namespace Simple.Abp.Articles.Public.Web.Shared.Components.Article
{
    public class ArticleViewComponent: AbpViewComponent
    {
        public IViewComponentResult Invoke(List<ArticleDto> modelList)
        {
            return View("~/Shared/Components/Article/Default.cshtml", modelList);
        }
    }
}
