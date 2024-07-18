using CompetencePlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Entities.Identity
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
        public int Priority { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public Role() : base() { }
        public Role(string name)
            : this()
        {
            this.Name = name;
        }

        public Role(string name, string description)
            : this(name)
        {
            this.Description = description;
        }
    }
}
