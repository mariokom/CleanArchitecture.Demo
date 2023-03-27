namespace Unic.Core.TokenAuthorization
{
    public class AuthorizationContext
    {
        public int UserId { get; set; }
        public string UserRole { get; set; } = string.Empty;
    }
}
