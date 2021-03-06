using System;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Articles.Dtos
{
    [Serializable]
    public class TagDto : CreationAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public int ArticleCount { get; set; }
    }
}