using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class CompetenceTypeController : ApiController
{
    private readonly ICompetenceTypeService _competenceTypeService;

    public CompetenceTypeController(ICompetenceTypeService competenceTypeService)
    {
        _competenceTypeService = competenceTypeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCompetenceTypeModel createCompetenceTypeModel)
    {
        return Ok(ApiResult<CompetenceTypeModel>.Success(
            await _competenceTypeService.Create(createCompetenceTypeModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateCompetenceTypeModel createCompetenceTypeModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<CompetenceTypeModel>.Success(await _competenceTypeService.Update(createCompetenceTypeModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<CompetenceTypeModel>.Success(await _competenceTypeService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<CompetenceTypeModel>>.Success(
             await _competenceTypeService.GetPagination(options)));

    }
}
