using System;
using System.Collections.Generic;
using System.Text;

namespace LnuCampaign.Core.Data.Entities
{
    public class ZnoCertificate : IBaseEntity
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public double Mark { get; set; }
    }
}
