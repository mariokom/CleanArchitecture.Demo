using CAD.Domain.Entities;

namespace CAD.Core.Shared.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Task<SystemUser?> GetSystemUser(int userId, CancellationToken cancellationToken);

        public Task<SystemUser?> GetSystemUser(string username, CancellationToken cancellationToken);
    }
}
