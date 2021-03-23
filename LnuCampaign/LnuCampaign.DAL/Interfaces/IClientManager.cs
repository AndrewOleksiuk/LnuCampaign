using LnuCampaign.DAL.Entities;
using System;

namespace LnuCampaign.DAL.Interfaces
{
    public interface IUserManager:IDisposable
    {
        void Create(UserProfile item);
    }
}
