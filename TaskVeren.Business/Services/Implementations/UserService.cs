using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.DTOs.User;
using TaskVeren.Business.Services.Interfaces;
using TaskVeren.Core.Entities;

namespace TaskVeren.Business.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> userManager;
        readonly IConfiguration configuration;
        readonly IMapper mapper;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.configuration = configuration;
        }
        public async Task Register(RegisterDto Dto)
        {
            if (await userManager.FindByEmailAsync(Dto.Email) != null)
            {
                throw new Exception();
            }
            var appuser = mapper.Map<AppUser>(Dto);
            var result = await userManager.CreateAsync(appuser, Dto.Password);
            if (!result.Succeeded)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    sb.Append(err.Description + " ");
                }
                throw new Exception(sb.ToString());
            }
        }
        public async Task<string> Login(LoginDto Dto)
        {
            var user = await userManager.FindByNameAsync(Dto.Username);
            if (user == null)
            {
                throw new Exception();
            }
            var result = await userManager.CheckPasswordAsync(user, Dto.Password);
            if (!result) throw new Exception();

            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecurityKey"]));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtToken = new JwtSecurityToken(
                audience: configuration["JWT:Audience"],
                issuer: configuration["JWT:Issuer"],
                claims: Claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(60)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
       

            string userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return token;

        }
    }
}
