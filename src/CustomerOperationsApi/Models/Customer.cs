namespace CustomerOperationsApi.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set;}
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public Contact Contacts { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
