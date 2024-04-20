using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Utils
{
    public class PageInfo
    {
        public PageInfo()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PageInfo(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Skip => (PageNumber - 1) * PageSize;
    }
}
