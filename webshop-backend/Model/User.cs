namespace webshop_backend.Model
{
    public class RegisterRequest
    {

        public int ID { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string AdminID { get; set; }
        public string Role { get; set; }
    }
    public class SignUpResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
