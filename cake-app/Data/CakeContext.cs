using cake_app.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace cake_app.Data
{
   public class CakeContext : DbContext
   {
      // create constructor
      public CakeContext(DbContextOptions<CakeContext> options) : base(options)
      {

      }

      // list a table
      public virtual DbSet<Cake> Cakes { get; set; }
   }
}
