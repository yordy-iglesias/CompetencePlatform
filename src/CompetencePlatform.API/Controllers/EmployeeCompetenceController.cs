using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.EmployeeCompetence;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class EmployeeCompetenceController : ApiController
{
    private readonly IEmployeeCompetenceService _employeeCompetenceService;

    public EmployeeCompetenceController(IEmployeeCompetenceService employeeCompetenceService)
    {
        _employeeCompetenceService = employeeCompetenceService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEmployeeCompetenceViewModel createEmployeeCompetenceModel)
    {
        return Ok(ApiResult<EmployeeCompetenceViewModel>.Success(
            await _employeeCompetenceService.Create(createEmployeeCompetenceModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateEmployeeCompetenceViewModel createEmployeeCompetenceModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<EmployeeCompetenceViewModel>.Success(await _employeeCompetenceService.Update(createEmployeeCompetenceModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<EmployeeCompetenceViewModel>.Success(await _employeeCompetenceService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<EmployeeCompetenceViewModel>>.Success(
             await _employeeCompetenceService.GetPagination(options)));

    }
}
