using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class DegreeCompetenceController : ApiController
{
    private readonly IDegreeCompetenceService _degreeCompetenceService;

    public DegreeCompetenceController(IDegreeCompetenceService degreeCompetenceService)
    {
        _degreeCompetenceService = degreeCompetenceService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateDegreeCompetenceViewModel createDegreeCompetenceModel)
    {
        return Ok(ApiResult<DegreeCompetenceViewModel>.Success(
            await _degreeCompetenceService.Create(createDegreeCompetenceModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateDegreeCompetenceViewModel createDegreeCompetenceModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<DegreeCompetenceViewModel>.Success(await _degreeCompetenceService.Update(createDegreeCompetenceModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<DegreeCompetenceViewModel>.Success(await _degreeCompetenceService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<DegreeCompetenceViewModel>>.Success(
             await _degreeCompetenceService.GetPagination(options)));

    }
}
