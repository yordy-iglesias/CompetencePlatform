using Microsoft.AspNetCore.Identity;

namespace CompetencePlatform.Core.DataAccess.Identity;

public class ApplicationUser : IdentityUser {
    public bool IsActive { get; set; }     
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
