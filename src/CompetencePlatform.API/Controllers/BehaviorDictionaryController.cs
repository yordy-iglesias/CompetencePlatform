using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class BehaviorDictionaryController : ApiController
{
    private readonly IBehaviorDictionaryService _behaviorDictionaryService;

    public BehaviorDictionaryController(IBehaviorDictionaryService behaviorDictionaryService)
    {
        _behaviorDictionaryService = behaviorDictionaryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBehaviorDictionaryModel createBehaviorDictionaryModel)
    {
        return Ok(ApiResult<BehaviorDictionaryModel>.Success(
            await _behaviorDictionaryService.Create(createBehaviorDictionaryModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateBehaviorDictionaryModel  createBehaviorDictionaryModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<BehaviorDictionaryModel>.Success(await _behaviorDictionaryService.Update(createBehaviorDictionaryModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<BehaviorDictionaryModel>.Success(await _behaviorDictionaryService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<BehaviorDictionaryModel>>.Success(
             await _behaviorDictionaryService.GetPagination(options)));

    }
}
