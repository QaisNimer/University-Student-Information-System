using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class TokenService
    {
        private static IConfiguration _configuration;
        public string SecretKey { get; }
        public static SymmetricSecurityKey SecurityKey { get; private set; }

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            SecretKey = _configuration["JwtSettings:SecretKey"];
            SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
        }

        public string GenerateResetToken(string emailaddress, out DateTime Expiration)
        {
            var expirationMinutes = int.Parse(_configuration["JwtSettings:ResetTokenExpirationMinutes"]);
            Expiration = DateTime.Now.AddMinutes(expirationMinutes);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, emailaddress),
                    new Claim(ClaimTypes.Expiration, Expiration.ToString())
                }),
                Expires = Expiration,
                SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidateResetToken(string token, string emailAddress, out DateTime expirationTime)
        {
            expirationTime = DateTime.MinValue;

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                var emailClaim = principal.FindFirst(ClaimTypes.Email);
                if (emailClaim == null || !emailClaim.Value.Equals(emailAddress, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                var expirationClaim = principal.FindFirst(ClaimTypes.Expiration);
                if (expirationClaim == null || !DateTime.TryParse(expirationClaim.Value, out expirationTime))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
