using System.Linq.Expressions;
using CompetencePlatform.Core.Common;
using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.Exceptions;
using CompetencePlatform.Core.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DatabaseContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(DatabaseContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        var addedEntity = (await DbSet.AddAsync(entity)).Entity;
        await Context.SaveChangesAsync();

        return addedEntity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        var removedEntity = DbSet.Remove(entity).Entity;
        await Context.SaveChangesAsync();

        return removedEntity;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync<TOrder>(Expression<Func<TEntity, TOrder>> order, SortOrder sortOrder = SortOrder.Ascending)
    {
        if (sortOrder == SortOrder.Ascending)
            return await DbSet.OrderBy(order).ToListAsync();
        return await DbSet.OrderByDescending(order).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllAsync<TOrder>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TOrder>> order, SortOrder sortOrder = SortOrder.Ascending)
    {
        if (sortOrder == SortOrder.Ascending)
            return await DbSet.Where(predicate).OrderBy(order).ToListAsync();
        return await DbSet.Where(predicate).OrderByDescending(order).ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }
    //Para obtener los valores agrupados
    public async Task<IEnumerable<IGrouping<object, TEntity>>> GetAllGroupByAsync(Expression<Func<TEntity, bool>> predicate, string fieldNameGroupBy)
    {
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        var property = Expression.Property(parameter, fieldNameGroupBy);
        var selector = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(object)), parameter);

        var groupedData = await DbSet.Where(predicate).GroupBy(selector).ToListAsync();

        return groupedData;
    }



    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate, bool asNoTracking)
    {
        var query = DbSet.Where(predicate);

        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }

        var entity = await query.FirstOrDefaultAsync();

        return entity;
    }


    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await Context.SaveChangesAsync();

        return entity;
    }

    public async Task<int> Count()
    {
        return await DbSet.CountAsync();
    }

    public async Task<int> Count(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.CountAsync(predicate);
    }
    public async Task<PageResult<TEntity>> GetPage<TOrder>(PageInfo pageInfo, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrder>> order, SortOrder sortOrder = SortOrder.Ascending)
    {
        List<TEntity> result;
        if (sortOrder == SortOrder.Ascending)
        {
            result = where == null ? result = DbSet.OrderBy(order).GetPage(pageInfo).ToList()
                : result = DbSet.Where(where).OrderBy(order).GetPage(pageInfo).ToList();
        }
        else
        {
            result = where == null ? DbSet.OrderByDescending(order).GetPage(pageInfo).ToList()
                : DbSet.Where(where).OrderByDescending(order).GetPage(pageInfo).ToList();
        }

        var total = DbSet.Count();
        var totalfilter = where == null ? total : DbSet.Count(where);

        var pageResult = new PageResult<TEntity>
        {
            Result = result,
            PageNumber = pageInfo.PageNumber,
            PageSize = pageInfo.PageSize,
            TotalFilter = totalfilter,
            Total = total
        };
        return pageResult;
    }

    
    public async Task<TEntity> GetByIdAsync(object id)
    {
        return await DbSet.FindAsync(id);
    }

    
}
