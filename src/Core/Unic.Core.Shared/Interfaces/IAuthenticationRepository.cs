using Unic.Domain.Entities;

namespace Unic.Core.Shared.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Task<SystemUser?> GetSystemUser(int userId, CancellationToken cancellationToken);

        public Task<SystemUser?> GetSystemUser(string username, CancellationToken cancellationToken);
    }
}
