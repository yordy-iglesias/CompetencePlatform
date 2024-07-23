using CompetencePlatform.Application.Models.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Application.Models.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool IsActive { get; set; } //EmailConfirmed        
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; }
        public int OrganizacionId { get; set; }
        public int IdRole { get; set; }
    }
}
