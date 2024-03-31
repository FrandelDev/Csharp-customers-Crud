namespace CustomerOperationsApi.Models
{
    public class CustomerModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string City { get; set; }
        public char Gender { get; set; }
    }
}
