using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LnuCampaign.Core.Data.Dto;
using LnuCampaign.Core.Data.Entities;

namespace LnuCampaign.BLL.Mapping
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }
}
