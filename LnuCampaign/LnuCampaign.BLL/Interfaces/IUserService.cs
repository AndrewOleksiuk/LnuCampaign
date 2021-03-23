using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LnuCampaign.BLL.DTO;
using LnuCampaign.BLL.Infrastructure;

namespace LnuCampaign.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDto userDto);
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
        Task SetInitialData(UserDto adminDto, List<string> roles);
    } 
}
