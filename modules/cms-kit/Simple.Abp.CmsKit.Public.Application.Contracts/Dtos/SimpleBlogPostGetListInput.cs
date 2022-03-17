using Volo.Abp.Application.Dtos;

namespace Simple.Abp.CmsKit.Public.Dtos
{
    public class SimpleBlogPostGetListInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
