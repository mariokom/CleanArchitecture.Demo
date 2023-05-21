using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAD.Domain.Entities;

namespace CAD.Core.Shared.Interfaces
{
    public interface ITokenManager
    {
        public string GenerateToken(int userIdint, string userRole);

        public string ParseToken(string token);
    }
}
