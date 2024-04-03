using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Services
{
    public static class ResponseApiService
    {

        public static ResponseApiModel Response(int statusCode, string message=null, object data=null)
        {
           
            if (statusCode >= 200 && statusCode <= 300)
            {
                return new ResponseApiModel()
                {
                    StatusCode = statusCode,
                    Success = true,
                    Message = message,
                    Data = data
                };
            }
            return new ResponseApiModel()
            {
                StatusCode = statusCode,
                Success = false,
                Message = message,
                Data = data
            };

        }
    }
}
