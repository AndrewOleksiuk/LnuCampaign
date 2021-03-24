using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using LnuCampaign.Core.Data.Dto;

namespace LnuCampaign.Core.Interfaces.Services
{
    public interface IAuthService
    {
        Task<SignInResult> SignInAsync(LoginDto loginDto);
        Task SignOutAsync();
        Task<IdentityResult> CreateUserAsync(RegisterDto registerDto);
    }
}
