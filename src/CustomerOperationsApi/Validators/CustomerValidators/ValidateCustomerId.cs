using CustomerOperationsApi.Models;
using System.Text.RegularExpressions;

namespace CustomerOperationsApi.Validators.CustomerValidator
{
    public static class ValidateCustomerId
    {

        public static ValidationResponse IsValid(string id)
        {
          
            if (id.Length != 13 || !Regex.IsMatch(id, "\\d{3}-\\d{7}-\\d"))
            {
                return new ValidationResponse(false,"Incorrect identificator format");
            }
           
            return new ValidationResponse(true);
        }
    }
}
