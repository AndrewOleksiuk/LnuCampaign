using LnuCampaign.DAL.EF;
using LnuCampaign.DAL.Entities;
using LnuCampaign.DAL.Interfaces;

namespace LnuCampaign.DAL.Repositories
{
    public class UserManager : IUserManager
    {
        public ApplicationContext Database { get; set; }
        public UserManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(UserProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
