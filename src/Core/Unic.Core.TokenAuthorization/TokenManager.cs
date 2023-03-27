using JWT.Algorithms;
using Unic.Core.Shared.Interfaces;
using JWT.Builder;

namespace Unic.Core.TokenAuthorization
{
    public class TokenManager : ITokenManager
    {
        public string GenerateToken(int userId, string userRole)
        {
            var token = JwtBuilder.Create()
                        .WithAlgorithm(new NoneAlgorithm())
                        .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                        .AddClaim("userId", userId)
                        .AddClaim("userRole", userRole)
                        .Encode();

            return token;

        }

        public string ParseToken(string token)
        {
            var json = JwtBuilder.Create()
                     .WithAlgorithm(new NoneAlgorithm())
                     .Decode(token);
            Console.WriteLine(json);

            return json;
        }
    }
}
