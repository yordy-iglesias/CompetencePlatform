using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities.Identity
{
    public class User : IdentityUser<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrganizacionId { get; set; }
        [ForeignKey("OrganizacionId")]
        public virtual Organization Organization { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Deleted { get; set; }
        public int ScreenAutoLockMinutes { get; set; }
        public string CultureId { get; set; } = "";
        public string TimeZoneId { get; set; } = "";
        public string AvatarUrl { get; set; } = "";
        public bool IsActive { get; set; }
        //public virtual ICollection<UserClaim> UserClaims { get; set; }
        //public virtual ICollection<UserLogin> UserLogins { get; set; }
        //public virtual ICollection<UserRole> UserRoles { get; set; }
        // virtual ICollection<Role> Roles { get; set; }


    }
}




