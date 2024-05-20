using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Application.Models.Project;
using CompetencePlatform.Application.Models.Resposability;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class ResponsabilityController : ApiController
{
    private readonly IResponsabilityService _responsabilityService;

    public ResponsabilityController(IResponsabilityService responsabilityService)
    {
        _responsabilityService = responsabilityService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateResponsabilityViewModel createResponsabilityModel)
    {
        return Ok(ApiResult<ResponsabilityViewModel>.Success(
            await _responsabilityService.Create(createResponsabilityModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateResponsabilityViewModel createResponsabilityModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<ResponsabilityViewModel>.Success(await _responsabilityService.Update(createResponsabilityModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<ResponsabilityViewModel>.Success(await _responsabilityService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<ResponsabilityViewModel>>.Success(
             await _responsabilityService.GetPagination(options)));

    }
}
