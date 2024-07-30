using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Application.Services;
using CompetencePlatform.Core.DataTable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompetencePlatform.API.Controllers;

[Authorize]
public class UsersController : ApiController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(ApiResult<IEnumerable<UserViewModel>>.Success(
             await _userService.Get()));
    }
    [HttpPost("getPagin")]
    public async Task<IActionResult> GetPagin(DataTableServerSide options)
    {
        return Ok(ApiResult<DataTablePagin<UserViewModel>>.Success(
             await _userService.GetPagination(options)));
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(ApiResult<UserViewModel>.Success(await _userService.Get(id)));
    }
    [HttpPut]
    public async Task<IActionResult> Update(UserViewModel updateUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(ApiResult<UserViewModel>.Success(await _userService.Update(updateUserModel)));
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterAsync(CreateUserModel createUserModel)
    {
        return Ok(ApiResult<CreateUserResponseModel>.Success(await _userService.CreateAsync(createUserModel)));
    }

    [HttpPost("authenticate")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginUserModel loginUserModel)
    {
        return Ok(ApiResult<LoginResponseModel>.Success(await _userService.LoginAsync(loginUserModel)));
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(ApiResult<UserViewModel>.Success(await _userService.Delete(id)));
    }
    [HttpGet("getSelect")]
    public async Task<IActionResult> GetSelect()
    {
        return Ok(ApiResult<IEnumerable<SelectViewModel>>.Success(
             await _userService.GetSelect()));
    }

    [HttpPost("confirmEmail")]
    public async Task<IActionResult> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel)
    {
        return Ok(ApiResult<ConfirmEmailResponseModel>.Success(
            await _userService.ConfirmEmailAsync(confirmEmailModel)));
    }

    [HttpPut("{id:guid}/changePassword")]
    public async Task<IActionResult> ChangePassword(Guid id, ChangePasswordModel changePasswordModel)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(
            await _userService.ChangePasswordAsync(id, changePasswordModel)));
    }
}
