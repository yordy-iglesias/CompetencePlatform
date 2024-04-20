using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Utils
{
    public class PageResult<TEntity>
    {
        public List<TEntity> Result { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalFilter { get; set; }
        public int Total { get; set; }
        public string OrderColumnName { get; set; }
    }
}
