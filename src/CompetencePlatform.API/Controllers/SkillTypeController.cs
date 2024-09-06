using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.Knowledge;
using CompetencePlatform.Application.Models.Motivation;
using CompetencePlatform.Application.Models.Preference;
using CompetencePlatform.Application.Models.PreferenceType;
using CompetencePlatform.Application.Models.SkillType;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class SkillTypeController : ApiController
{
    private readonly ISkillTypeService _skillTypeService;

    public SkillTypeController(ISkillTypeService skillTypeService)
    {
        _skillTypeService = skillTypeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateSkillTypeViewModel createSkillTypeModel)
    {
        return Ok(ApiResult<SkillTypeViewModel>.Success(
            await _skillTypeService.Create(createSkillTypeModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateSkillTypeViewModel createSkillTypeModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<SkillTypeViewModel>.Success(await _skillTypeService.Update(createSkillTypeModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<SkillTypeViewModel>.Success(await _skillTypeService.Delete(id)));
    }
    [HttpDelete("DeletePrime/{id:int}")]
    public async Task<IActionResult> DeletePrime(int id)
    {
        return Ok(ApiResult<SkillTypeViewModel>.Success(await _skillTypeService.DeletePrime(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<SkillTypeViewModel>>.Success(
             await _skillTypeService.GetPagination(options)));

    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(ApiResult<IEnumerable<SkillTypeViewModel>>.Success(
             await _skillTypeService.Get()));
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(ApiResult<CreateSkillTypeViewModel>.Success(await _skillTypeService.Get(id)));
    }
    
    [HttpGet]
    [Route("IsUnique")]
    public async Task<bool> IsUnique(string key, string value)
    {
        return await _skillTypeService.IsUnique(key, value);
    }
    [HttpGet]
    [Route("hasChildren")]
    public async Task<bool> HasChildren(int id)
    {
        return await _skillTypeService.HasChildren(id);
    }
    [HttpGet]
    [Route("restore")]
    public async Task<IActionResult> Restore(int id)
    {
        return Ok(ApiResult<SkillTypeViewModel>.Success(await _skillTypeService.Restore(id)));
    }
}
