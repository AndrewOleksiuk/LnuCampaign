using LnuCampaign.BLL.Interfaces;
using LnuCampaign.DAL.Repositories;

namespace LnuCampaign.BLL.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
