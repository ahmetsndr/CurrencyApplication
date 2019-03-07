using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data
{
    public class CurrencyDBContext : DbContext
    {
        public  CurrencyDBContext() : base("CurrencyDBConnectionString")
        {
        }

        public DbSet<Currency.Data.Entities.Currency> Currency { get; set; }
    }
}
