using Microsoft.EntityFrameworkCore;
using CAD.Core.Shared.Interfaces;
using CAD.Domain.Entities;

namespace CAD.Infrastructure.Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthenticationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SystemUser?> GetSystemUser(string username, CancellationToken cancellationToken)
        {
            return await _dbContext.SystemUser
                .FirstOrDefaultAsync(user => user.Username == username, cancellationToken);
        }

        public async Task<SystemUser?> GetSystemUser(int userId, CancellationToken cancellationToken)
        {
            return await _dbContext.SystemUser
                .FirstOrDefaultAsync(user => user.Id == userId, cancellationToken);
        }
    }
}
