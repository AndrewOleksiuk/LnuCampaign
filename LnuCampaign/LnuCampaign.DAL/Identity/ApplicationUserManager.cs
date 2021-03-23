using LnuCampaign.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace LnuCampaign.DAL.Identity
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store)
                : base(store)
        {
        }
    }
}
