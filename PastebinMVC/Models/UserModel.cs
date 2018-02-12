using PastebinMVC.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PastebinMVC.Models
{
    public class UserModel : IValidatableObject
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var user = Facade.GetUserByUsernameAndPassword(Username, Password);
            if (user != null)
            {
                if (Username != user.Username)
                    yield return new ValidationResult("You dind't provide a valid username!", new[] { "Username" });
                if(Password != user.Password)
                   yield return new ValidationResult("You dind't provide a valid password!", new[] { "Password" });

            }
            else
            {
                yield return new ValidationResult("Invalid credentials!");
            }
        }
    }
}