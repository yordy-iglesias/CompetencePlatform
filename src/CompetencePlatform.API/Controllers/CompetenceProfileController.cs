using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.BehaviorDictionary;
using CompetencePlatform.Application.Models.C_S_M_K_P;
using CompetencePlatform.Application.Models.Competence;
using CompetencePlatform.Application.Models.CompetenceProfile;
using CompetencePlatform.Application.Models.TodoItem;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompetencePlatform.API.Controllers;

[Authorize]
public class CompetenceProfileController : ApiController
{
    private readonly ICompetenceProfileService _competenceProfileService;

    public CompetenceProfileController(ICompetenceProfileService competenceProfileService)
    {
        _competenceProfileService = competenceProfileService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCompetenceProfileModel createCompetenceProfileModel)
    {
        return Ok(ApiResult<CompetenceProfileModel>.Success(
            await _competenceProfileService.Create(createCompetenceProfileModel)));
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] CreateCompetenceProfileModel createCompetenceProfileModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<CompetenceProfileModel>.Success(await _competenceProfileService.Update(createCompetenceProfileModel)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<CompetenceProfileModel>.Success(await _competenceProfileService.Delete(id)));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {

        return Ok(ApiResult<DataTablePagin<CompetenceProfileModel>>.Success(
             await _competenceProfileService.GetPagination(options)));

    }
}
