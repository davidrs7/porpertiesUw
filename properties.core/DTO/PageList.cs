using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace properties.core.DTO
{
    public class PageList<T> : List<T>
    {
        public int currentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }       
        public bool PreviousPage => currentPage > 1;
        public bool NextPage => currentPage < TotalCount ;
        public int? NextPageNumber => NextPage? currentPage + 1: (int?)null;
        public int? PreviousPageNumber => PreviousPage ? currentPage - 1: (int?)null;
        public PageList(List<T> items,int count, int pageNumber, int PageSizer)
        {
            TotalCount = count;
            PageSize = PageSizer;
            currentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            AddRange(items);
        }

        public static PageList<T> Create(IEnumerable<T> source, int PageNumber, int PageSize)
        {
            var count = source.Count();
            var items = source.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            return new PageList<T>(items, count, PageNumber, PageSize);
        }

    }
}
