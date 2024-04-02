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
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public ValidationResponse(bool success, string? message=null)
        {
            this.IsSuccess = success;
            this.Message = message;
        }
    }
}
