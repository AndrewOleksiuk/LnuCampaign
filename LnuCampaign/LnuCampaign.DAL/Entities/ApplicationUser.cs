using Microsoft.AspNet.Identity.EntityFramework;

namespace LnuCampaign.DAL.Entities
{
    public class User : IdentityUser
    {
        public virtual UserProfile ClientProfile { get; set; }
    }
}
