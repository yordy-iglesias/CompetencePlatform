using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Application.Models.Project;
using CompetencePlatform.Application.Models.ProjectTeam;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class ProjectTeamController : ApiController
{
    private readonly IProjectTeamService _projectTeamService;

    public ProjectTeamController(IProjectTeamService projectTeamService)
    {
        _projectTeamService = projectTeamService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProjectTeamViewModel createProjectTeamModel)
    {
        return Ok(ApiResult<ProjectTeamViewModel>.Success(await _projectTeamService.Create(createProjectTeamModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateProjectTeamViewModel createProjectTeamModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<ProjectTeamViewModel>.Success(await _projectTeamService.Update(createProjectTeamModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<ProjectTeamViewModel>.Success(await _projectTeamService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<ProjectTeamViewModel>>.Success(
             await _projectTeamService.GetPagination(options)));

    }
}
