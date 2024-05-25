using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceDictionary;
using CompetencePlatform.Application.Models.CompetenceProfile;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class CompetenceDictionaryController : ApiController
{
    private readonly ICompetenceDictionaryService _competenceDictionaryService;

    public CompetenceDictionaryController(ICompetenceDictionaryService competenceDictionaryService)
    {
        _competenceDictionaryService = competenceDictionaryService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCompetenceDictionaryViewModel createCompetenceDictionaryViewModel)
    {
        return Ok(ApiResult<CompetenceDictionaryViewModel>.Success(
            await _competenceDictionaryService.Create(createCompetenceDictionaryViewModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateCompetenceDictionaryViewModel createCompetenceDictionaryViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<CompetenceDictionaryViewModel>.Success(await _competenceDictionaryService.Update(createCompetenceDictionaryViewModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<CompetenceDictionaryViewModel>.Success(await _competenceDictionaryService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<CompetenceDictionaryViewModel>>.Success(
             await _competenceDictionaryService.GetPagination(options)));

    }
}
