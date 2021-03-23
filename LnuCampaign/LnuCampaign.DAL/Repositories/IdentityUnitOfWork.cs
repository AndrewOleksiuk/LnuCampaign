using LnuCampaign.DAL.EF;
using LnuCampaign.DAL.Entities;
using LnuCampaign.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using LnuCampaign.DAL.Identity;

namespace LnuCampaign.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;

        private readonly ApplicationUserManager applicationUserManager;
        private readonly ApplicationRoleManager roleManager;
        private readonly IUserManager userManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            applicationUserManager = new ApplicationUserManager(new UserStore<User>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            userManager = new UserManager(db);
        }

        public ApplicationUserManager ApplicationUserManager
        {
            get { return applicationUserManager; }
        }

        public IUserManager UserManager
        {
            get { return userManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    userManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
