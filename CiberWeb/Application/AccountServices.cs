using CiberWeb.Common;
using CiberWeb.Interface;
using CiberWeb.Models;
using CiberWeb.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient.Server;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;

namespace CiberWeb.Application
{
    public class AccountServices : IAccountServices
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        public AccountServices(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Task<UserVM> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<string>> Login(LoginRequest loginViewModel)
        {
            if (string.IsNullOrEmpty(loginViewModel.UserName) || string.IsNullOrEmpty(loginViewModel.Password))
            {
                return new ErrorResult<string>("User name and password is required");
            }
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user == null) { return new ErrorResult<string>("Account not exit"); }
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, true);
            if (!result.Succeeded)
            {
                return new ErrorResult<string>("UserName or password is incorrect");
            }
            var role = await _userManager.GetRolesAsync(user);
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName,user.Name),
                new Claim(ClaimTypes.Role, string.Join(";", role)), 
                new Claim(ClaimTypes.Name,user.UserName),

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SECRET_KEY));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                Constants.Issue,
                Constants.Issue,
                claim,
                expires: DateTime.Now.AddHours(30),
                signingCredentials: creds
                );
            return new SuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<Result<bool>> Register(RegisterRequest registerViewModel)
        {
            var user = await _userManager.FindByNameAsync(registerViewModel.UserName);
            if (user != null)
            {
                return new ErrorResult<bool>("Account has already exists");
            }
            var email = await _userManager.FindByEmailAsync(registerViewModel.Email);
            if(email!=null)
            {
                return new ErrorResult<bool>("Email has already exists");
            }

            user = new AppUser()
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                Name = registerViewModel.FullName,
                Address = registerViewModel.Address
            };
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                return new SuccessResult<bool>();
            }
            else
            {
                return new ErrorResult<bool>("Signup failed");
            }
        }
    }
}
