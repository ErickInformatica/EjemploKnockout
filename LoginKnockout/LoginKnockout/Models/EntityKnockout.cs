namespace LoginKnockout.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityKnockout : DbContext
    {
        public EntityKnockout()
            : base("name=EntityKnockout")
        {
        }

        public virtual DbSet<Grafica> Grafica { get; set; }
        public virtual DbSet<Opinion> Opinion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Opinion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Opinion>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Opinion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Pass)
                .IsUnicode(false);
        }
    }
}
