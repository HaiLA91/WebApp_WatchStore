namespace WebApi.Models
{
    public class RegisterModel
    {
        public string? Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string? Role { get; set; }
    }
}
