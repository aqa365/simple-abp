using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles.Dtos
{
    public class ArticlePagedRequestDto : ArticlesPageRequestDto
    {
        [StringLength(ArticleCatalogConsts.MaxTitleLength)]
        public string CatalogTitle { get; set; }

        [StringLength(ArticleTagConsts.MaxNameLength)]
        public string TagName { get; set; }
    }
}
