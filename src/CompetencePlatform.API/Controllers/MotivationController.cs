using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class MotivationController : ApiController
{
    private readonly IMotivationService _motivationService;

    public MotivationController(IMotivationService motivationService)
    {
        _motivationService = motivationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateMotivationViewModel createMotivationModel)
    {
        return Ok(ApiResult<MotivationViewModel>.Success(
            await _motivationService.Create(createMotivationModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateMotivationViewModel createMotivationModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<MotivationViewModel>.Success(await _motivationService.Update(createMotivationModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<MotivationViewModel>.Success(await _motivationService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<MotivationViewModel>>.Success(
             await _motivationService.GetPagination(options)));

    }
}
