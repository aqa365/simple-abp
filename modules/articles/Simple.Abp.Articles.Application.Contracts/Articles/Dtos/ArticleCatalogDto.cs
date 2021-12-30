using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class ArticleCatalogDto : FullAuditedEntityDto<Guid>
    {
        public Guid? ParentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ArticleCount { get; set; }

        public List<ArticleCatalogDto> Childs { get; set; }
    }
}