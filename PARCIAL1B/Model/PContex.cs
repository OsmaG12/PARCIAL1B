using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace PARCIAL1B.Model
{
    public class PContex : DbContext
    {
        public PContex(DbContextOptions< PContex> option) : base(option)
        {

        }

        public DbSet<Platos> platos { get; set; }
        public DbSet<PlatosPorCombo> platosPC { get; set; }
        public DbSet<Elementos> elementos { get; set; }
        public DbSet<ElementosPorPlato> elementosPP { get; set; }

    }

        

}
