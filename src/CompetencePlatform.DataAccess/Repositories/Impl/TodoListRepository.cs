using CompetencePlatform.Core.DataAccess.Persistence;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Core.DataAccess.Repositories.Impl;

public class TodoListRepository : BaseRepository<TodoList>, ITodoListRepository
{
    public TodoListRepository(DatabaseContext context) : base(context) { }
}
