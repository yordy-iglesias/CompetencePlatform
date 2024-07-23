using CompetencePlatform.Application.Models;

namespace CompetencePlatform.Application.Models.User;

public class CreateUserModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int IdOrganization { get; set; }
    public int IdRol { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }
