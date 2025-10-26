using KA_11.BLL.Services.Interfaces;
using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using KA_11.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;

        public AuthenticationService(
            UserManager<ApplicationUser> userManager ,
            IConfiguration configuration,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
        }
        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                throw new Exception("Invalid Email or Password");
            }
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new Exception("Email not confirmed");
            }
            var isPassValid = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
            if (!isPassValid)
            {
                throw new Exception("Invalid Password");
            }
            return new UserResponse()
            {
                Token = await CreateTokenAsync(user),
            };
        }
        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found ");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return "Email confirmed successfully";
            }
            else
            {
                throw new Exception("Email confirmation failed");
            }
        }

        public async Task<UserResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            var user = new ApplicationUser
            {
                FullName = registerRequest.FullName,
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,
            };
            var Result = await _userManager.CreateAsync(user, registerRequest.Password);
            if (Result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var escapToken = Uri.EscapeDataString(token);
                var emailConfirmationLink = $"https://localhost:7174/api/Identity/Account/ConfirmEmail?token={escapToken}&userId={user.Id}";
                _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                    $"<h1>Hello {registerRequest.FullName}</h1><br>Please confirm your account by clicking this link: <a href='{emailConfirmationLink}'>Click here</a>");
                return new UserResponse()
                {
                    Token = registerRequest.Email
                };
            }
            else
            {
                var errors = string.Join(", ", Result.Errors.Select(e => $"{e.Code}: {e.Description}"));
                throw new Exception(errors);
            }
        }
        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var Claims = new List<Claim>()
            {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.NameIdentifier, user.Id),

            };
            var Roles = await _userManager.GetRolesAsync(user);
            foreach (var role in Roles)
            {
                Claims.Add(new Claim(ClaimTypes.Role, role)); 
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: Claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials 
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    } 
}

