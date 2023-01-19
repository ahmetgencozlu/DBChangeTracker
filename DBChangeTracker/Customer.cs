namespace DBChangeTracker
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsPhoneAllowed { get; set; }
        public bool IsEmailAllowed { get; set; }
        public bool IsCallAllowed { get; set; }
    }
}
