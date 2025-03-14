﻿using CompetencePlatform.Application.Models.TodoList;
using CompetencePlatform.Application.Models.Validators.TodoList;
using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using Xunit;

namespace CompetencePlatform.Application.UnitTests.Validators;

public class UpdateTodoListModelValidatorTests
{
    private readonly UpdateTodoListModelValidator _sut;

    public UpdateTodoListModelValidatorTests()
    {
        _sut = new UpdateTodoListModelValidator();
    }

    [Fact]
    public void Validator_Should_Have_Error_When_Title_Is_Empty()
    {
        // Arrange
        var updateTodoListModel = new UpdateTodoListModel { Title = string.Empty };

        // Act
        var result = _sut.TestValidate(updateTodoListModel);

        // Assert
        result.ShouldHaveValidationErrorFor(utl => utl.Title);
    }

    [Fact]
    public void Validator_Should_Not_Have_Error_When_All_Inputs_Are_Ok()
    {
        // Arrange
        var updateTodoListModel = Builder<UpdateTodoListModel>.CreateNew().Build();

        // Act
        var result = _sut.TestValidate(updateTodoListModel);

        // Assert
        result.ShouldNotHaveValidationErrorFor(utl => utl.Title);
    }
}
