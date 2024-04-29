using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class C_S_M_K_PController : ApiController
{
    private readonly IC_S_M_K_PService _c_S_M_K_PService;

    public C_S_M_K_PController(IC_S_M_K_PService c_S_M_K_PService)
    {
        _c_S_M_K_PService = c_S_M_K_PService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateC_S_M_K_PModel createC_S_M_K_PModel)
    {
        return Ok(ApiResult<C_S_M_K_PModel>.Success(
            await _c_S_M_K_PService.Create(createC_S_M_K_PModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateC_S_M_K_PModel createC_S_M_K_PModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<C_S_M_K_PModel>.Success(await _c_S_M_K_PService.Update(createC_S_M_K_PModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<C_S_M_K_PModel>.Success(await _c_S_M_K_PService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<C_S_M_K_PModel>>.Success(
             await _c_S_M_K_PService.GetPagination(options)));

    }
}
