using MediatR;

namespace CAD.Core.Shared.Commands
{
    public class AuthenticateCommand : IRequest<string>
    {
        public string Username { get; }
        public string Password { get; }

        public AuthenticateCommand(string username, string password) 
        {
            Username = username;
            Password = password;
        }
    }
}
