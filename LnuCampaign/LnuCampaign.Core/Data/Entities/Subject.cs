using System;
using System.Collections.Generic;
using System.Text;

namespace LnuCampaign.Core.Data.Entities
{
    public class Subject: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
