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
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class SolutionDomainController : ApiController
{
    private readonly ISolutionDomainService _solutionDomainService;

    public SolutionDomainController(ISolutionDomainService solutionDomainService)
    {
        _solutionDomainService = solutionDomainService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSolutionDomainViewModel createSolutionDomainModel)
    {
        return Ok(ApiResult<SolutionDomainViewModel>.Success(
            await _solutionDomainService.Create(createSolutionDomainModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateSolutionDomainViewModel createSolutionDomainModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<SolutionDomainViewModel>.Success(await _solutionDomainService.Update(createSolutionDomainModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<SolutionDomainViewModel>.Success(await _solutionDomainService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<SolutionDomainViewModel>>.Success(
             await _solutionDomainService.GetPagination(options)));

    }
}
