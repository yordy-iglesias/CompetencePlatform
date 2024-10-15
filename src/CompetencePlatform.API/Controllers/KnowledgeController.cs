using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
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
public class KnowledgeController : ApiController
{
    private readonly IKnowledgeService _knowledgeService;

    public KnowledgeController(IKnowledgeService knowledgeService)
    {
        _knowledgeService = knowledgeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateKnowledgeViewModel createKnowledgeModel)
    {
        return Ok(ApiResult<KnowledgeViewModel>.Success(
            await _knowledgeService.Create(createKnowledgeModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateKnowledgeViewModel createKnowledgeModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<KnowledgeViewModel>.Success(await _knowledgeService.Update(createKnowledgeModel)));
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(ApiResult<CreateKnowledgeViewModel>.Success(await _knowledgeService.Get(id)));
    }
    [HttpDelete("DeletePrime/{id:int}")]
    public async Task<IActionResult> DeletePrime(int id)
    {
        return Ok(ApiResult<KnowledgeViewModel>.Success(await _knowledgeService.DeletePrime(id)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<KnowledgeViewModel>.Success(await _knowledgeService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<KnowledgeViewModel>>.Success(
             await _knowledgeService.GetPagination(options)));

    }
    [HttpGet]
    [Route("IsUnique")]
    public async Task<bool> IsUnique(string key, string value)
    {
        return await _knowledgeService.IsUnique(key, value);
    }
    [HttpGet]
    [Route("hasChildren")]
    public async Task<bool> HasChildren(int id)
    {
        return await _knowledgeService.HasChildren(id);
    }
    [HttpGet]
    [Route("restore")]
    public async Task<IActionResult> Restore(int id)
    {
        return Ok(ApiResult<KnowledgeViewModel>.Success(await _knowledgeService.Restore(id)));
    }
}
