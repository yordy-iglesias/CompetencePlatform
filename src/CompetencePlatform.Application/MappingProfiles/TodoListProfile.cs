using AutoMapper;
using CompetencePlatform.Application.Models.TodoList;
using CompetencePlatform.Core.Entities;


namespace CompetencePlatform.Application.MappingProfiles;

public class TodoListProfile : Profile
{
    public TodoListProfile()
    {
        CreateMap<CreateTodoListModel, TodoList>();

        CreateMap<TodoList, TodoListResponseModel>();
    }
}
