using System;
using System.ComponentModel.DataAnnotations;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class CreateUpdateArticleTagDto
    {
        [Required]
        [StringLength(ArticleTagConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}