using CustomerOperationsApi.Models;
using System.Text.RegularExpressions;

namespace CustomerOperationsApi.Validators.CustomerValidator
{
    public static class CustomerValidator
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


     

    public class ValidationResponse
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        public ValidationResponse(bool success, string? message = default)
        {
            this.IsSuccess = success;
            this.Message = message;
        }
    }
}
