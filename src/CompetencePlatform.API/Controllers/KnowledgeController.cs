using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
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
}
