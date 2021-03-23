using LnuCampaign.BLL.DTO;
using LnuCampaign.BLL.Infrastructure;
using LnuCampaign.DAL.Entities;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using LnuCampaign.BLL.Interfaces;
using LnuCampaign.DAL.Interfaces;
using System.Collections.Generic;

namespace LnuCampaign.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            User user = await Database.ApplicationUserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, UserName = userDto.Email };
                await Database.ApplicationUserManager.CreateAsync(user, userDto.Password);
                await Database.ApplicationUserManager.AddToRoleAsync(user.Id, userDto.Role);
                UserProfile clientProfile = new UserProfile { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                Database.UserManager.Create(clientProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Registered", "");

            }
            else
            {
                return new OperationDetails(false, "Login exists", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            User user = await Database.ApplicationUserManager.FindAsync(userDto.Email, userDto.Password);
            if(user!=null)
                claim= await Database.ApplicationUserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDto adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await Database.RoleManager.CreateAsync(role);
                }
            }

            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }

    
}
