using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Core.DataTable;

namespace CompetencePlatform.Application.Services;

public interface IUserService: ICrudInterface<UserViewModel, DataTableServerSide>
{
    Task<BaseResponseModel> ChangePasswordAsync(Guid userId, ChangePasswordModel changePasswordModel);
    Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel);
    Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel);
    Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
    Task<string> GetUser(int userId);
    Task<UserViewModel> Delete(int id);
    Task<UserViewModel> Get(int id);
    Task<string> GetCurrentUserName();
}
