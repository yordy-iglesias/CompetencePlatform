using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.EmployeeProfile;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class EmployeeProfileController : ApiController
{
    private readonly IEmployeeProfileService _employeeProfileService;

    public EmployeeProfileController(IEmployeeProfileService employeeProfileService)
    {
        _employeeProfileService = employeeProfileService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateEmployeeProfileViewModel createEmployeeProfileModel)
    {
        return Ok(ApiResult<EmployeeProfileViewModel>.Success(
            await _employeeProfileService.Create(createEmployeeProfileModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateEmployeeProfileViewModel createEmployeeProfileModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<EmployeeProfileViewModel>.Success(await _employeeProfileService.Update(createEmployeeProfileModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<EmployeeProfileViewModel>.Success(await _employeeProfileService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<EmployeeProfileViewModel>>.Success(
             await _employeeProfileService.GetPagination(options)));

    }
}
