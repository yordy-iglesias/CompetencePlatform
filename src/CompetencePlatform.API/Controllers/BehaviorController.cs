using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class BehaviorController : ApiController
{
    private readonly IBehaviorService _behaviorService;

    public BehaviorController(IBehaviorService behaviorService)
    {
        _behaviorService = behaviorService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBehaviorModel createBehaviorModel)
    {
        return Ok(ApiResult<BehaviorModel>.Success(
            await _behaviorService.Create(createBehaviorModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateBehaviorModel createBehaviorModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<BehaviorModel>.Success(await _behaviorService.Update(createBehaviorModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<BehaviorModel>.Success(await _behaviorService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<BehaviorModel>>.Success(
             await _behaviorService.GetPagination(options)));

    }
}
