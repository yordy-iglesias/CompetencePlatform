using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Application.Services.Impl;
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
    public async Task<IActionResult> CreateAsync(CreateBehaviorViewModel createBehaviorModel)
    {
        return Ok(ApiResult<BehaviorViewModel>.Success(
            await _behaviorService.Create(createBehaviorModel)));
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(ApiResult<CreateBehaviorViewModel>.Success(await _behaviorService.Get(id)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateBehaviorViewModel createBehaviorModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<BehaviorViewModel>.Success(await _behaviorService.Update(createBehaviorModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<BehaviorViewModel>.Success(await _behaviorService.Delete(id)));
    }
    [HttpDelete("DeletePrime/{id:int}")]
    public async Task<IActionResult> DeletePrime(int id)
    {
        return Ok(ApiResult<BehaviorViewModel>.Success(await _behaviorService.DeletePrime(id)));
    }
    [HttpGet]
    [Route("IsUnique")]
    public async Task<bool> IsUnique(string key, string value)
    {
        return await _behaviorService.IsUnique(key, value);
    }
    [HttpGet]
    [Route("hasChildren")]
    public async Task<bool> HasChildren(int id)
    {
        return await _behaviorService.HasChildren(id);
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<BehaviorViewModel>>.Success(
             await _behaviorService.GetPagination(options)));

    }
    [HttpGet]
    [Route("restore")]
    public async Task<IActionResult> Restore(int id)
    {
        return Ok(ApiResult<BehaviorViewModel>.Success(await _behaviorService.Restore(id)));
    }
}
