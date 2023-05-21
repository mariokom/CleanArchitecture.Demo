using MediatR;
using System.Text.Json;
using CAD.Core.Shared.Commands;
using CAD.Core.Shared.Interfaces;
using CAD.Domain.Entities;

namespace CAD.Core.UseCases.Commands
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, string>
    {
        private readonly IAuthenticationRepository _authRepository;
        private readonly ITokenManager _tokenManager;
        private readonly IHashManager _hashManager;

        public AuthenticateCommandHandler(IAuthenticationRepository authRepository, 
            ITokenManager tokenManager, IHashManager hashManager)
        {
            _authRepository = authRepository;
            _tokenManager = tokenManager;
            _hashManager = hashManager;
        }

        public async Task<string> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            SystemUser? systemUser = await _authRepository.GetSystemUser(request.Username.ToLower(), cancellationToken);
            if (systemUser == default)
            {
                throw new Exception("Invalid username or password");
            }

            string dbPassword = systemUser.Password;
            string expectedPassword = _hashManager.Hash(request.Password, systemUser.PasswordSalt);
            if (dbPassword != expectedPassword)
            {
                throw new Exception("Invalid username or password");
            }

            return await Task.FromResult(
                _tokenManager.GenerateToken(systemUser.Id, systemUser.Role.ToString())
            );
        }
    }
}
