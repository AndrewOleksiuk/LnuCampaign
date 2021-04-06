using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LnuCampaign.Core.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace LnuCampaign.Core.Data.Dto
{
    public class UserDataDto : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public double AverageMark { get; set; }
        public IFormFile SchoolCertificate { get; set; }
        public List<ZnoCertificate> ZnoCertificates { get; set; } 
    }
}
