using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;


namespace CompetencePlatform.Core.DataAccess.Repositories;

public interface IBaseRepository<TEntity> where TEntity :class
{
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> GetAllAsync<TOrder>(Expression<Func<TEntity, TOrder>> order, SortOrder sortOrder = SortOrder.Ascending);
    Task<List<TEntity>> GetAllAsync<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, SortOrder sortOrder = SortOrder.Ascending);
    Task<IEnumerable<IGrouping<object, TEntity>>> GetAllGroupByAsync(Expression<Func<TEntity, bool>> predicate, string fieldNameGroupBy);
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task<TEntity> DeleteAsync(TEntity entity);

    Task<PageResult<TEntity>> GetPage<TOrder>(PageInfo pageInfo, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrder>> order, SortOrder sortOrder = SortOrder.Ascending);


    Task<int> Count();
    Task<int> Count(Expression<Func<TEntity, bool>> predicate);
    

    Task<TEntity> GetByIdAsync(object id);
}
