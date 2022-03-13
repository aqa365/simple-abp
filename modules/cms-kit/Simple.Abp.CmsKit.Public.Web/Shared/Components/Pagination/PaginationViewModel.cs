using System;

namespace Simple.Abp.CmsKit.Public.Web.Shared.Components.Pagination
{
    public class PaginationViewModel
    {
        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        /// <summary>
        /// /writing/page/{pageindex}?filter=xxx
        /// </summary>
        public string UrlTemplate { get; set; }

        public bool IsPrev
        {
            get
            {
                if (PageIndex <= 1)
                    return false;

                return true;
            }
        }

        public string Prev => GetUrlByPageIndex(PageIndex-1);

        public bool IsNext
        {
            get
            {
                if (PageIndex < PageCount)
                    return true;

                return false;
            }
        }

        public string Next => GetUrlByPageIndex(PageIndex + 1);


        public PaginationViewModel(int pageIndex, int pageSize, long totalCount,
            string urlTemplate)
        {
            PageIndex = pageIndex;
            PageCount = (int)Math.Ceiling(totalCount * 1d / pageSize);
            UrlTemplate = urlTemplate;
        }

        public string GetUrlByPageIndex(int pageIndex)
            => UrlTemplate.Replace("{pageindex}", pageIndex.ToString());


    }
}
