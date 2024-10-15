using Microsoft.EntityFrameworkCore;
using GestionTareasAPI.Models;

namespace GestionTareasAPI.DataAccess
{
    //Contexto de la base de datos para las tareas
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>().HasKey(t => t.Id);
            modelBuilder.Entity<Tarea>().Property(t => t.Descripcion).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Tarea>().Property(t => t.FechaCreacion).HasDefaultValueSql("GETDATE()");
        }
    }
}
