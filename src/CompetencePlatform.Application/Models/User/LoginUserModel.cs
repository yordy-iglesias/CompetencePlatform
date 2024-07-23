using CompetencePlatform.Application.Models.Role;

namespace CompetencePlatform.Application.Models.User;

public class LoginUserModel
{
    public string Username { get; set; }

    public string Password { get; set; }
}

public class LoginResponseModel
{
    public string Username { get; set; }

    public string Email { get; set; }
    public string Token { get; set; }

    public IEnumerable<RoleViewModel> Role { get; set; }
}
