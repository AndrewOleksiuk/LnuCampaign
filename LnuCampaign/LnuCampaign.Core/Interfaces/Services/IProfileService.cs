using System.Threading.Tasks;
using LnuCampaign.Core.Data.Dto;
using LnuCampaign.Core.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace LnuCampaign.Core.Interfaces.Services
{
    public interface  IProfileService
    {
        User UpdateUserData(UserDataDto model);
    }
}
