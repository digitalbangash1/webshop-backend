namespace webshop_backend.Model
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
    }

    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
