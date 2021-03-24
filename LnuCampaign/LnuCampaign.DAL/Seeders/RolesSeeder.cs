using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LnuCampaign.Core.Configuration;
using LnuCampaign.Core.Data.Entities;

namespace LnuCampaign.DAL.Seeders
{
    class RolesSeeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    Id = new Guid("0e575c95-8003-4920-bfcc-c6803decc482"),
                    Name = Roles.Administrator,
                    NormalizedName = Roles.Administrator.ToUpperInvariant(),
                    ConcurrencyStamp = "a168fe73-bdd8-4d15-9f2f-7c38fdda54b6"
                });
            modelBuilder.Entity<Role>()
                .HasData(new Role
                {
                    Id = new Guid("986d8317-ed04-464a-921c-c3866a488566"),
                    Name = Roles.User,
                    NormalizedName = Roles.User.ToUpperInvariant(),
                    ConcurrencyStamp = "c7a901e8-6c4b-4a30-9cc2-9b20a7bf1c39"
                });
        }
    }
}
