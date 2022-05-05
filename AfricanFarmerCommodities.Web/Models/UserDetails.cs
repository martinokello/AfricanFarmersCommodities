namespace AfricanFarmersCommodities.Models
{
    public class UserDetails
    {
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string password { get; set; }
        public string repassword { get; set; }
        public bool keepLoggedIn { get; set; }
        public string authToken { get; set; }
    }

    public class UserCredential
    {
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string mobileNumber { get; set; }
        public string authToken { get; set; }
    }
    public class UserRole
    {
        public string role { get; set; }
        public string email { get; set; }
    }
    public class ResetPassword
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string Repassword { get; set; }
    }
}