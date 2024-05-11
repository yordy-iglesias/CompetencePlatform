using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Application.Models.SkillType;
using CompetencePlatform.Application.Models.SolutionDomain;
using CompetencePlatform.Application.Models.SolutionDomainCompetence;
using CompetencePlatform.Application.Models.Team;
using CompetencePlatform.Application.Models.TechnicalSheet;
using CompetencePlatform.Application.Models.TechnicalSheetCompose;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class TechnicalSheetController : ApiController
{
    private readonly ITechnicalSheetService _technicalSheetService;

    public TechnicalSheetController(ITechnicalSheetService technicalSheetService)
    {
        _technicalSheetService = technicalSheetService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTechnicalSheetViewModel createTechnicalSheetViewModel)
    {
        return Ok(ApiResult<TechnicalSheetViewModel>.Success(
            await _technicalSheetService.Create(createTechnicalSheetViewModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateTechnicalSheetViewModel createTechnicalSheetViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<TechnicalSheetViewModel>.Success(await _technicalSheetService.Update(createTechnicalSheetViewModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<TechnicalSheetViewModel>.Success(await _technicalSheetService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<TechnicalSheetViewModel>>.Success(
             await _technicalSheetService.GetPagination(options)));

    }
}
