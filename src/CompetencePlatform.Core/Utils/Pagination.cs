using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Utils
{
    public static class Pagination
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, PageInfo pageInfo)
        {
            return queryable.Skip(pageInfo.Skip).Take(pageInfo.PageSize);
        }
    }
}
