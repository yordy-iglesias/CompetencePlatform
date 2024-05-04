using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.DegreeCompetence;
using CompetencePlatform.Application.Models.Employee;
using CompetencePlatform.Application.Models.EmployeeCompetence;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class EmployeeController : ApiController
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEmployeeViewModel createEmployeeModel)
    {
        return Ok(ApiResult<EmployeeViewModel>.Success(
            await _employeeService.Create(createEmployeeModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateEmployeeViewModel createEmployeeModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<EmployeeViewModel>.Success(await _employeeService.Update(createEmployeeModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<EmployeeViewModel>.Success(await _employeeService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<EmployeeViewModel>>.Success(
             await _employeeService.GetPagination(options)));

    }
}
