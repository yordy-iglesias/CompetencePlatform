using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.Behaviour;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Application.Services.Impl;
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
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(ApiResult<CreateMotivationViewModel>.Success(await _motivationService.Get(id)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<MotivationViewModel>.Success(await _motivationService.Delete(id)));
    }
    [HttpDelete("DeletePrime/{id:int}")]
    public async Task<IActionResult> DeletePrime(int id)
    {
        return Ok(ApiResult<MotivationViewModel>.Success(await _motivationService.DeletePrime(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<MotivationViewModel>>.Success(
             await _motivationService.GetPagination(options)));

    }
    [HttpGet]
    [Route("IsUnique")]
    public async Task<bool> IsUnique(string key, string value)
    {
        return await _motivationService.IsUnique(key, value);
    }
    [HttpGet]
    [Route("hasChildren")]
    public async Task<bool> HasChildren(int id)
    {
        return await _motivationService.HasChildren(id);
    }
    [HttpGet]
    [Route("restore")]
    public async Task<IActionResult> Restore(int id)
    {
        return Ok(ApiResult<MotivationViewModel>.Success(await _motivationService.Restore(id)));
    }
}
