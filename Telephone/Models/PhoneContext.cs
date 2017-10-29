using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone.Models
{
    class PhoneContext : DbContext
    {
        public PhoneContext() : base("DefaultConnection")
        {

        }

        public DbSet<CorporativeTelephone> CorpPhones { get; set; }
        public DbSet<PersonalTelephone> PersPhone { get; set; }
    }
}
