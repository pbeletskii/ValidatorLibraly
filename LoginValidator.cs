using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidatorLibraly
{
    public class LoginValidator : IValidator
    {
        public bool Validate(string? validateObject)
        {
            if (string.IsNullOrEmpty(validateObject) || validateObject.Length < 6 || validateObject.Length > 16)
            {
                return false;
            }

            return Regex.IsMatch(validateObject, "^[a-zA-Z]");
        }
    }
}
