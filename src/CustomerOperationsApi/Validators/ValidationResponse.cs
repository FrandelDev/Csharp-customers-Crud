namespace CustomerOperationsApi.Validators
{
    public class ValidationResponse
    {
        public bool IsSuccess { get; private set; }
        public string? Message { get; private set; }

        public ValidationResponse(bool success, string? message = default)
        {
            this.IsSuccess = success;
            this.Message = message;
        }
    }
}
