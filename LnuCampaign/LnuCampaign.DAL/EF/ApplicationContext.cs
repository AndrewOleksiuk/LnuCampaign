using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using LnuCampaign.DAL.Entities;

namespace LnuCampaign.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<User>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<UserProfile> ClientProfiles { get; set; }
    }
}
