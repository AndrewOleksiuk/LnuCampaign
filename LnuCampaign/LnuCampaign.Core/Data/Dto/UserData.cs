using System;
using System.Collections.Generic;
using System.Text;
using LnuCampaign.Core.Data.Entities;

namespace LnuCampaign.Core.Data.Dto
{
    public class UserData : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
