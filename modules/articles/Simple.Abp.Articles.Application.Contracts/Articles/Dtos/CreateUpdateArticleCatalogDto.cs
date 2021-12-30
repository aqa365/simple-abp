using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleCatalogDto
    {
        public virtual Guid? ParentId { get; set; }

        [Required]
        [StringLength(ArticleCatalogConsts.MaxTitleLength)]
        public virtual string Title { get; set; }

        [StringLength(ArticleCatalogConsts.MaxDescriptionLength)]
        public virtual string Description { get; set; }
    }
}