﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Identity;
using LnuCampaign.Core.Interfaces.DataAccess.Base;

namespace LnuCampaign.Core.Data.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity<Guid>, IIdentifiable<Guid>, ISaveTrackable, IInactivebleAt
    {
        public bool? IsSystemAdmin { get; set; }
        [StringLength(128)]
        public string FirstName { get; set; }
        [StringLength(128)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime2", Order = 101)]
        public DateTime? InactiveAt { get; set; }
        [NotMapped]
        public bool HasPassword => !string.IsNullOrEmpty(PasswordHash);
        [NotMapped]
        public string DisplayName => $"{FirstName} {LastName}";
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
