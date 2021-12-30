using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Articles
{
    public class Article:FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 类别id
        /// </summary>
        public Guid? CatalogId { get; set; }

        /// <summary>
        /// seo path
        /// </summary>
        public string SEOPath { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 是否加精
        /// </summary>
        public bool IsRefinement { get; set; }

        /// <summary>
        /// 文章状态
        /// </summary>
        public EnumArticleState State { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [ForeignKey("CatalogId")]
        public ArticleCatalog Catalog { get; set; }


        protected Article()
        {
        }

        public Article(
            Guid id,
            Guid? catalogId,
            string title,
            string tag,
            string summary,
            string content,
            bool isTop,
            bool isRefinement,
            EnumArticleState state,
            int order,
            ArticleCatalog catalog
        ) : base(id)
        {
            CatalogId = catalogId;
            Title = title;
            Tag = tag;
            Summary = summary;
            Content = content;
            IsTop = isTop;
            IsRefinement = isRefinement;
            State = state;
            Order = order;
            Catalog = catalog;
        }
    }
}
