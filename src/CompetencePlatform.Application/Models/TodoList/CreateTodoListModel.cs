﻿using CompetencePlatform.Application.Models;

namespace CompetencePlatform.Application.Models.TodoList;

public class CreateTodoListModel
{
    public string Title { get; set; }
}

public class CreateTodoListResponseModel : BaseResponseModel { }
