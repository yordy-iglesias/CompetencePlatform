

using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Core.DataTable;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Services
{
    public interface ICrudInterface<T, in D> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<SelectViewModel>> GetSelect();
        Task<T> Create(T entity);
        Task<T> Delete(int id);
        Task<T> Get(int id);
        Task<T> Update(T entity);
        Task<DataTablePagin<T>> GetPagination(D options);
    }

    public interface ICrudInterface<T, C, in D> where T : class where C : class
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<SelectViewModel>> GetSelect();
        Task<T> Create(C entity);
        Task<T> Delete(int id);
        Task<C> Get(int id);
        Task<T> GetDetails(int id);
        Task<T> Update(C entity);
        Task<DataTablePagin<T>> GetPagination(D options);
        
    }
}
