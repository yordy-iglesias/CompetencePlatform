using CompetencePlatform.Application.Models;

namespace CompetencePlatform.Application.Models.TodoList;

public class UpdateTodoListModel
{
    public string Title { get; set; }
}

public class UpdateTodoListResponseModel : BaseResponseModel { }
