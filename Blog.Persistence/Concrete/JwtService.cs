using Blog.Application.Abstracts.Persistence;
using Blog.Application.Features.Users.Results;
using Blog.Application.Options;
using Blog.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Persistence.Concrete
{
    public class JwtService(UserManager<AppUser> _userManager,IOptions<JwtTokenOptions> options) : IJwtService
    {
        private readonly JwtTokenOptions _jwtTokenOptions = options.Value;
        public async Task<GetLoginQueryResult> GenerateTokenAsync(GetUsersQueryResult result)
        {
           var user = await _userManager.FindByIdAsync(result.Id.ToString());
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key));
            var dateTimeNow = DateTime.UtcNow;
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName",string.Join(" ",user.FirstName,user.LastName))
            };
            JwtSecurityToken jwtSecurityToken = new(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                claims: claims,
                notBefore: dateTimeNow,
                expires: dateTimeNow.AddMinutes(_jwtTokenOptions.ExpireTime),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            GetLoginQueryResult response = new()
            {
                GenerateToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                ExpirationDate = dateTimeNow.AddMinutes(_jwtTokenOptions.ExpireTime)
            };
            return response;
        }
    }
}
