using Microsoft.EntityFrameworkCore;
using BoletosBusApp.Data.Entities.Configuration;

namespace BoletosBusApp.Data.Context
{
    public class BoletoContext : DbContext
    {
        public BoletoContext(DbContextOptions<BoletoContext> options) : base(options)
        {
            
        }

        #region "DbSets"

        public DbSet<Bus> Buses { get; set; }
        public DbSet<Asiento> Asientos { get; set; }
 
        #endregion
    }
}
