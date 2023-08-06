
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Identity.API.Application.Settings.Auth
{
    public class AuthSetting
    {

        public string Secret { get; set; }
        public int TimeExpiration { get; set; }
        public string Issuer { get; set; }
        public string ValidIn { get; set; }
        

        public string GetJwt()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = Issuer,
                Audience = ValidIn,
                Expires = DateTime.UtcNow.AddHours(TimeExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
