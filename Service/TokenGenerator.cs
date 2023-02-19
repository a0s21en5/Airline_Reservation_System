using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Airline_Reservation_System.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int userId, string userName)
        {
            var userClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userName)
            };

            //Secret Key - "asdfghjklqwertyuiopzxcvbnm"
            //Encoding the Secret Key
            var userSecretKey = Encoding.UTF8.GetBytes("asdfghjklqwertyuiopzxcvbnm");

            //Conver the Encoded key to symmetric key
            var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKey);

            //Sign the Token
            var userSigningCredentials = new SigningCredentials(userSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var userJwtSecurityToken = new JwtSecurityToken(
                issuer: "AirlineReservationSystemMVCApp",
                audience: "AirlineReservationSystemMVCAppUsers",
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: userSigningCredentials);

            var userJwtSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken);
            return userJwtSecurityTokenHandler;
        }

        public bool IsTokenValid(string userToken, string userSecretKey, string userIssuer, string userAudience)
        {
            var userSecretKeyInBytes = Encoding.UTF8.GetBytes(userSecretKey);
            var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKeyInBytes);
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = userIssuer,

                ValidateAudience = true,
                ValidAudience = userAudience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = userSymmetricSecurityKey,

                ValidateLifetime = true,
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                tokenHandler.ValidateToken(userToken, tokenValidationParameters, out SecurityToken securityToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
