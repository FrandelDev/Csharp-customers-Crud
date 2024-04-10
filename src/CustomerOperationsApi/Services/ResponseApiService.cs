using CustomerOperationsApi.Models;

namespace CustomerOperationsApi.Services
{
    public static class ResponseApiService
    {

        public static ResponseApi Response(int statusCode, string? message =default, object? data=default)
        {
           
            if (statusCode >= 200 && statusCode <= 300)
            {
                return new ResponseApi()
                {
                    StatusCode = statusCode,
                    Success = true,
                    Message = message,
                    Data = data
                };
            }
            return new ResponseApi()
            {
                StatusCode = statusCode,
                Success = false,
                Message = message,
                Data = data
            };

        }
    }
}
