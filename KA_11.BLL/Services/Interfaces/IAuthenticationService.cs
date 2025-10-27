using KA_11.DAL.DTO.Requests;
using KA_11.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_11.BLL.Services.Interfaces
{
    public interface IAuthenticationService
    {
         Task<UserResponse> LoginAsync(LoginRequest loginRequest);
         Task<UserResponse> RegisterAsync(RegisterRequest registerRequest);
         Task<string> ConfirmEmailAsync(string userId, string token);
         Task<string> ForgotPasswordAsync(ForgotPasswordRequest request);
         Task<bool> ResetPasswordAsync(ResetPassword request);


    }
}
