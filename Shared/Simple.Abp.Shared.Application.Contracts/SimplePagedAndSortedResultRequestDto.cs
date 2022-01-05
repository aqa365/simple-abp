using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Simple.Abp.Shared
{
    public class SimplePagedAndSortedResultRequestDto: PagedAndSortedResultRequestDto
    {
        [StringLength(20)]
        public string? Filter { get; set; }

        public int PageSize
        {
            get
            {
                return MaxResultCount;
            }
            set
            {
                MaxResultCount = value;
            }
        }

        private int _pageIndex;
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;

                if (_pageIndex <= 0)
                    _pageIndex = 1;

                SkipCount = (_pageIndex - 1) * MaxResultCount;
            }
        }
    }
}
