
namespace Unic.Domain.Entities
{
    public class SystemUser
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PasswordSalt { get; set; } = string.Empty;
        public UserRole Role { get; set; }
    }
}
