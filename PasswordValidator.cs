using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidatorLibraly
{
    public class PasswordValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrEmpty(validateObject) || validateObject.Length < 8 || validateObject.Length > 20)
            {
                return false;
            }

            return Regex.IsMatch(validateObject, "^(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*-_])[a-zA-Z0-9!@#$%^&*-_]*$");
        }
    }
}
