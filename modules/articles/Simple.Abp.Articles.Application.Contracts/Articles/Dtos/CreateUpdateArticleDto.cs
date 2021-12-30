using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleDto
    {
        [Required]
        public virtual Guid? CatalogId { get; set; }

        [Required]
        [StringLength(ArticleConsts.MaxTitleLength)]
        public virtual string Title { get; set; }

        [Required]
        [StringLength(ArticleTagConsts.MaxNameLength)]
        public virtual string Tag { get; set; }

        [Required]
        [StringLength(ArticleConsts.MaxSEOPathLength)]
        public string SEOPath { get; set; }

        [StringLength(ArticleConsts.MaxSummaryLength)]
        public virtual string Summary { get; set; }

        [Required]
        public virtual string Content { get; set; }

        public virtual bool IsTop { get; set; }

        public virtual bool IsRefinement { get; set; }

        public virtual EnumArticleState State { get; set; } = EnumArticleState.Default;

        public int Order { get; set; } = 0;
    }
}