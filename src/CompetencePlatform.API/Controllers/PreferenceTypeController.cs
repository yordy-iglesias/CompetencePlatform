using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class PreferenceTypeController : ApiController
{
    private readonly IPreferenceTypeService _preferenceTypeService;

    public PreferenceTypeController(IPreferenceTypeService preferenceTypeService)
    {
        _preferenceTypeService = preferenceTypeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreatePreferenceTypeViewModel createPreferenceTypeModel)
    {
        return Ok(ApiResult<PreferenceTypeViewModel>.Success(
            await _preferenceTypeService.Create(createPreferenceTypeModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreatePreferenceTypeViewModel createTypePreferenceModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<PreferenceTypeViewModel>.Success(await _preferenceTypeService.Update(createTypePreferenceModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<PreferenceTypeViewModel>.Success(await _preferenceTypeService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<PreferenceTypeViewModel>>.Success(
             await _preferenceTypeService.GetPagination(options)));

    }
}
