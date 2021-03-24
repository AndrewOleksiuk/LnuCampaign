using System;
using LnuCampaign.Core.Data.Entities;
using LnuCampaign.Core.Interfaces.DataAccess.Base;

namespace LnuCampaign.Core.Interfaces.DataAccess
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
    }
}
