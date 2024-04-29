using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class CompetenceController : ApiController
{
    private readonly ICompetenceService _competenceService;

    public CompetenceController(ICompetenceService competenceService)
    {
        _competenceService = competenceService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCompetenceModel createCompetenceModel)
    {
        return Ok(ApiResult<CompetenceModel>.Success(
            await _competenceService.Create(createCompetenceModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateCompetenceModel createCompetenceModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<CompetenceModel>.Success(await _competenceService.Update(createCompetenceModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<CompetenceModel>.Success(await _competenceService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<CompetenceModel>>.Success(
             await _competenceService.GetPagination(options)));

    }
}
