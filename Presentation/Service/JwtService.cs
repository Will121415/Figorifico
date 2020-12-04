using System.Net.Mail;
using Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Presentation.Config;
using Presentation.Models;

namespace Presentation.Service
{
    public class JwtService
    {
         private readonly AppSetting _appSettings;
        public JwtService(IOptions<AppSetting> appSettings) => _appSettings = appSettings.Value;
        public LoginViewModel GenerateToken(User userLogIn)
        {
            // return null if user not found
            if (userLogIn == null) return null;

            var userResponse = new LoginViewModel() {
                
                UserName = userLogIn.UserName,
                Status = userLogIn.Status,
                Role = userLogIn.Role 
            };
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userLogIn.UserName.ToString()),
                    new Claim(ClaimTypes.Expired, userLogIn.Status.ToString()),
                    new Claim(ClaimTypes.Role, userLogIn.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userResponse.Token = tokenHandler.WriteToken(token);
            return userResponse;
        }
    }
}