using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Utils
{
    public class ModifyClave
    {
        public static string Modify(string clave) 
        {
            string patron = "[^a-zA-Z0-9 ]";
            return Regex.Replace(clave, patron, "");
        }
    }
}
