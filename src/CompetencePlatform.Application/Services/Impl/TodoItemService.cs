using AutoMapper;
using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataAccess.Repositories;
using CompetencePlatform.Core.Entities;

namespace CompetencePlatform.Application.Services.Impl;

public class TodoItemService : ITodoItemService
{
    private readonly IMapper _mapper;
    private readonly ITodoItemRepository _todoItemRepository;
    private readonly ITodoListRepository _todoListRepository;

    public TodoItemService(ITodoItemRepository todoItemRepository,
        ITodoListRepository todoListRepository,
        IMapper mapper)
    {
        _todoItemRepository = todoItemRepository;
        _todoListRepository = todoListRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodoItemResponseModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        //var todoItems =await _todoItemRepository.GetAllAsync(ti => ti.List.Id == id);

        return _mapper.Map<IEnumerable<TodoItemResponseModel>>(null);
    }

    public async Task<CreateTodoItemResponseModel> CreateAsync(CreateTodoItemModel createTodoItemModel,
        CancellationToken cancellationToken = default)
    {
        //var todoList = await _todoListRepository.GetFirstAsync(tl => tl.Id == (createTodoItemModel.TodoListId);
        //var todoItem = _mapper.Map<TodoItem>(createTodoItemModel);

        //todoItem.List = todoList;

        return new CreateTodoItemResponseModel
        {
            Id = Guid.NewGuid()//(await _todoItemRepository.AddAsync(todoItem)).Id
        };
    }

    public async Task<UpdateTodoItemResponseModel> UpdateAsync(Guid id, UpdateTodoItemModel updateTodoItemModel,
        CancellationToken cancellationToken = default)
    {
        //var todoItem = await _todoItemRepository.GetFirstAsync(ti => ti.Id == id);
        var todoItem = await _todoItemRepository.GetFirstAsync(ti => ti.Id == 0);

        _mapper.Map(updateTodoItemModel, todoItem);

        return new UpdateTodoItemResponseModel
        {
            Id = Guid.NewGuid()//(await _todoItemRepository.UpdateAsync(todoItem)).Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
       // var todoItem = await _todoItemRepository.GetFirstAsync(ti => ti.Id == id);
        var todoItem = await _todoItemRepository.GetFirstAsync(ti => ti.Id == 0);

        return new BaseResponseModel
        {
            Id = Guid.NewGuid()//(await _todoItemRepository.DeleteAsync(todoItem)).Id
        };
    }
}
