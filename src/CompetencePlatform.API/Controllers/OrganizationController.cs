using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.Organization;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class OrganizationController : ApiController
{
    private readonly IOrganizationService _organizationService;

    public OrganizationController(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateOrganizationViewModel createOrganizationViewModel)
    {
        return Ok(ApiResult<OrganizationViewModel>.Success(
            await _organizationService.Create(createOrganizationViewModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateOrganizationViewModel createOrganizationViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<OrganizationViewModel>.Success(await _organizationService.Update(createOrganizationViewModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<OrganizationViewModel>.Success(await _organizationService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<OrganizationViewModel>>.Success(
             await _organizationService.GetPagination(options)));

    }
}
