using System.ComponentModel.DataAnnotations;

namespace Xprepay
{
    public class PageRequest
    {
        public PageRequest()
        {
            CurrentPage = 1;
            Sorter = "CreatedTime";
            PageSize = 10;
            SortDirection = "descend";
        }
        private int _pageSize;
        [Display(Name = "currentPage")]
        public int CurrentPage { get; set; }
        [Display(Name = "pageSize")]
        public int PageSize
        {
            get { return _pageSize ; }
            set
            {
                if (value > 50)
                {
                    _pageSize = 50;
                }
                else
                {
                    _pageSize = value;
                }
            }
        }
        [Display(Name = "sorter")]
        public string Sorter { get; set; }
        [Display(Name = "sortDirection")]
        public string SortDirection { get; set; }
    }
}
