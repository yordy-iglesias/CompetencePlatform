using CompetencePlatform.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetencePlatform.Core.Utils
{
    public class PasswordHasher : IPasswordHasher<User>
    {
        private readonly AdvancedEncryptionStandardProvider _provider;
  

        public PasswordHasher()
        {
            _provider = new AdvancedEncryptionStandardProvider("Competence-Plataform--", "A5192652jfH4s254"); ;
        }


        public string HashPassword(User user, string password)
        {
            // Do no hashing
            var result = this._provider.Encrypt(password);
            return result;
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {

            // Throw an error if any of our passwords are null
            if (hashedPassword == null || providedPassword == null)
            {
                throw new Exception($"Not null values....hashedPassword: {hashedPassword} and providedPassword: {providedPassword}");
            }

            // Just check if the two values are the same
            if (hashedPassword.Equals(this.HashPassword(user, providedPassword)))
            {
                return PasswordVerificationResult.Success;
            }

            // Fallback
            return PasswordVerificationResult.Failed;
        }
    }
}
