using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Xml.Linq;

namespace User_API_for_Airline_Reservation_System.Service
{
    public class TokenGenerator : ITokenGenerator
    {
        public string GenerateToken(int id, string name, string role)
        {
            var userClaims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName,name,role)
            };

            //Secret Key - "asdfghjklqwertyuiopzxcvbnm"
            //Encoding the Secret Key
            var userSecretKey = Encoding.UTF8.GetBytes("asdfghjklqwertyuiopzxcvbnm");

            //Conver the Encoded key to symmetric key
            var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKey);

            //Sign the Token
            var userSigningCredentials = new SigningCredentials(userSymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var userJwtSecurityToken = new JwtSecurityToken(
                issuer: "AirlineReservationSystemwithAPI",
                audience: "AirlineReservationSystemwithAPIUsers",
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: userSigningCredentials);

            var userSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(userJwtSecurityToken);

            string userJwtSecurityTokenHandler = JsonConvert.SerializeObject(new { Token = userSecurityTokenHandler, Name = name, Role =  role});


            return userJwtSecurityTokenHandler;
        }
    }
}
