using System.Data.Entity;

namespace SistemaGestionClientes.Models
{
    public class TallerDbContext : DbContext
    {
        public TallerDbContext() : base("name=TallerConnectionString")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}