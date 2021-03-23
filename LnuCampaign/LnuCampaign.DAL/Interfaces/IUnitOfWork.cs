using LnuCampaign.DAL.Identity;
using System;
using System.Threading.Tasks;

namespace LnuCampaign.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager ApplicationUserManager { get; }
        IUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
