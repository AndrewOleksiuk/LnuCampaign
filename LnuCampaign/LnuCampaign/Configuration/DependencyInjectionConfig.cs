using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LnuCampaign.Core.Configuration;
using LnuCampaign.Core.Data.Entities;
using LnuCampaign.Core.Interfaces.DataAccess;
using LnuCampaign.Core.Interfaces.DataAccess.Base;
using LnuCampaign.Core.Interfaces.Services;
using LnuCampaign.DAL;
using LnuCampaign.DAL.Repositories;
using LnuCampaign.BLL;

namespace LnuCampaign.Configuration
{
    public class DependencyInjectionConfig
    {
        public static void Init(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // BLL
            services.AddScoped<IAuthService, AuthService>();

            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
