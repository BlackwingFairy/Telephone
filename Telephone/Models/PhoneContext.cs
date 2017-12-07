using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone.Models
{
    public class PhoneContext : DbContext
    {
        public PhoneContext() : base("DefaultConnection")
        {

        }

        public virtual DbSet<CorporativeTelephone> CorpPhones { get; set; }
        public virtual DbSet<PersonalTelephone> PersPhone { get; set; }
    }
}
