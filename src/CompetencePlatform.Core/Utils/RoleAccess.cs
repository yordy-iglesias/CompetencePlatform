using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Utils
{
    public class RoleAccess
    {
        public int Id { get; set; }
        public string RolName { get; set; }
        public List<Access> Accesses { get; set; }
        
    }

    public class Access
    {
        public string screenName { get; set; }
        public List<string> Actions {  get; set; }
    }
}
