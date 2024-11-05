using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.Departament;
using CompetencePlatform.Application.Models.Organization;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class DepartamentController : ApiController
{
    private readonly IDepartamentService _departamentService;

    public DepartamentController(IDepartamentService departamentService)
    {
        _departamentService = departamentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDepartamentViewModel createDepartamentViewModel)
    {
        return Ok(ApiResult<DepartamentViewModel>.Success(
            await _departamentService.Create(createDepartamentViewModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateDepartamentViewModel createDepartamentViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<DepartamentViewModel>.Success(await _departamentService.Update(createDepartamentViewModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<DepartamentViewModel>.Success(await _departamentService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<DepartamentViewModel>>.Success(
             await _departamentService.GetPagination(options)));

    }
    
}
