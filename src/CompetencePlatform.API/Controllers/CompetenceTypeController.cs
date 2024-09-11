using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceType;
using CompetencePlatform.Application.Models.SkillType;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Application.Services.Impl;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class CompetenceTypeController : ApiController
{
    private readonly ICompetenceTypeService _competenceTypeService;

    public CompetenceTypeController(ICompetenceTypeService competenceTypeService)
    {
        _competenceTypeService = competenceTypeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCompetenceTypeViewModel createCompetenceTypeModel)
    {
        return Ok(ApiResult<CompetenceTypeViewModel>.Success(
            await _competenceTypeService.Create(createCompetenceTypeModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateCompetenceTypeViewModel createCompetenceTypeModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<CompetenceTypeViewModel>.Success(await _competenceTypeService.Update(createCompetenceTypeModel)));
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(ApiResult<IEnumerable<CompetenceTypeViewModel>>.Success(
             await _competenceTypeService.Get()));
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(ApiResult<CreateCompetenceTypeViewModel>.Success(await _competenceTypeService.Get(id)));
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<CompetenceTypeViewModel>.Success(await _competenceTypeService.Delete(id)));
    }
    [HttpDelete("DeletePrime/{id:int}")]
    public async Task<IActionResult> DeletePrime(int id)
    {
        return Ok(ApiResult<CompetenceTypeViewModel>.Success(await _competenceTypeService.DeletePrime(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<CompetenceTypeViewModel>>.Success(
             await _competenceTypeService.GetPagination(options)));

    }
    [HttpGet]
    [Route("IsUnique")]
    public async Task<bool> IsUnique(string key, string value)
    {
        return await _competenceTypeService.IsUnique(key, value);
    }
    [HttpGet]
    [Route("hasChildren")]
    public async Task<bool> HasChildren(int id)
    {
        return await _competenceTypeService.HasChildren(id);
    }
    [HttpGet]
    [Route("restore")]
    public async Task<IActionResult> Restore(int id)
    {
        return Ok(ApiResult<CompetenceTypeViewModel>.Success(await _competenceTypeService.Restore(id)));
    }
}
