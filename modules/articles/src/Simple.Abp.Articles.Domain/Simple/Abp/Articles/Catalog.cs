using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simple.Abp.Articles
{
    public class Catalog : FullAuditedEntity<Guid>
    {
        public Guid? ParentId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        protected Catalog()
        {
        }

        public Catalog(
            Guid id,
            Guid? parentId,
            string title,
            string description
        ) : base(id)
        {
            ParentId = parentId;
            Title = title;
            Description = description;
        }
    }
}
