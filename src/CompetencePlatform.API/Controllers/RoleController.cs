using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.Role;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using CompetencePlatform.Core.Entities.Identity;
using CompetencePlatform.Core.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompetencePlatform.API.Controllers;

public class RoleController : ApiController
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(ApiResult<RoleViewModel>.Success(await _roleService.Get(id)));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(ApiResult<IEnumerable<RoleViewModel>>.Success(await _roleService.Get()));
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromBody] RoleAccess model, int id)
    {
        return Ok(ApiResult<RoleViewModel>.Success(await _roleService.Update(model, id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoleAccess model)
    {
        return Ok(ApiResult<RoleViewModel>.Success(await _roleService.Create(model)));
    }

    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {
        return Ok(ApiResult<DataTablePagin<RoleViewModel>>.Success(await _roleService.GetPagination(options)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(ApiResult<RoleViewModel>.Success(await _roleService.Delete(id)));
    }

    [HttpGet("getScreen")]
    public async Task<IActionResult> GetScreen()
    {
        return Ok(ApiResult<IEnumerable<string>>.Success(await _roleService.GetScreen()));
    }


    [HttpGet("GetSelect")]
    public async Task<IActionResult> GetSelect()
    {
        return Ok(ApiResult<IEnumerable<SelectViewModel>>.Success(await _roleService.GetSelect()));

    }
}

    
