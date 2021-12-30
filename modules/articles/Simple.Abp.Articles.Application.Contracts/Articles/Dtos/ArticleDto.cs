using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class ArticleDto : FullAuditedEntityDto<Guid>
    {
        public Guid? CatalogId { get; set; }

        public string Title { get; set; }

        public string Tag { get; set; }

        public string SEOPath { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public bool IsRefinement { get; set; }

        public EnumArticleState State { get; set; }

        public int Order { get; set; }

        public ArticleCatalogDto Catalog { get; set; }

        public ArticleDto Previous { get; set; }

        public ArticleDto Next { get; set; }

        public string DisplayState
        {
            get
            {
                return State.ToString();
            }
        }

        public string FrontCreationTime
        {
            get
            {
                return CreationTime.ToString("MMM dd, yyyy",
                    new System.Globalization.CultureInfo("en-us"));
            }
        }

        public string FrontUrl
        {
            get
            {
                return "/article" + SEOPath;
            }
        }
    }
}