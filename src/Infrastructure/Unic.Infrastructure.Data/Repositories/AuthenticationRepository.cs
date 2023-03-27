using Microsoft.EntityFrameworkCore;
using Unic.Core.Shared.Interfaces;
using Unic.Domain.Entities;

namespace Unic.Infrastructure.Data.Repositories
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
