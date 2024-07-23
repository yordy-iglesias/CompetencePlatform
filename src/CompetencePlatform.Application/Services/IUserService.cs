using CompetencePlatform.Application.Models;
using CompetencePlatform.Application.Models.User;
using CompetencePlatform.Core.DataTable;

namespace CompetencePlatform.Application.Services;

public interface IUserService
{
    Task<BaseResponseModel> ChangePasswordAsync(Guid userId, ChangePasswordModel changePasswordModel);

    Task<ConfirmEmailResponseModel> ConfirmEmailAsync(ConfirmEmailModel confirmEmailModel);

    Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel);
    Task<IEnumerable<UserViewModel>> Get();
    Task<string> GetCurrentUserName();
    Task<DataTablePagin<UserViewModel>> GetPagination(DataTableServerSide options);
    Task<IEnumerable<SelectViewModel>> GetSelect();
    Task<string> GetUser(int userId);
    Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
    Task<UserViewModel> Update(UserViewModel entity);
    Task<CreateUserResponseModel> UpdateAsync(CreateUserModel createUserModel);
}
