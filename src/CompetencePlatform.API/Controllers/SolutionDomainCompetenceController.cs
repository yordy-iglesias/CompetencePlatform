﻿using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Application.Models.SkillType;
using CompetencePlatform.Application.Models.SolutionDomainCompetence;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class SolutionDomainCompetenceController : ApiController
{
    private readonly ISolutionDomainCompetenceService _solutionDomainCompetenceService;

    public SolutionDomainCompetenceController(ISolutionDomainCompetenceService solutionDomainCompetenceService)
    {
        _solutionDomainCompetenceService = solutionDomainCompetenceService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSolutionDomainCompetenceViewModel createSolutionDomainCompetenceModel)
    {
        return Ok(ApiResult<SolutionDomainCompetenceViewModel>.Success(
            await _solutionDomainCompetenceService.Create(createSolutionDomainCompetenceModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateSolutionDomainCompetenceViewModel createSolutionDomainCompetenceModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<SolutionDomainCompetenceViewModel>.Success(await _solutionDomainCompetenceService.Update(createSolutionDomainCompetenceModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<SolutionDomainCompetenceViewModel>.Success(await _solutionDomainCompetenceService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<SolutionDomainCompetenceViewModel>>.Success(
             await _solutionDomainCompetenceService.GetPagination(options)));

    }
}
