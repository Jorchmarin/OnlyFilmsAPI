using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using API.Models;

#nullable disable

namespace API.Data
{
    public partial class OnlyFilmsContext : DbContext
    {
        public OnlyFilmsContext()
        {
        }

        public OnlyFilmsContext(DbContextOptions<OnlyFilmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<PeliculasGenero> PeliculasGeneros { get; set; }
        public virtual DbSet<Puntuacion> Puntuacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=mssql;Persist Security Info=True;User ID=sa;Password=mssql1Ipw");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("FK__Comentari__Id_Pe__52793849");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Comentari__Id_Us__536D5C82");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Valoration).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<PeliculasGenero>(entity =>
            {
                entity.ToTable("Peliculas/Genero");

                entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");

                entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.PeliculasGeneros)
                    .HasForeignKey(d => d.IdGenero)
                    .HasConstraintName("FK__Peliculas__Id_Ge__4F9CCB9E");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.PeliculasGeneros)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("FK__Peliculas__Id_Pe__4EA8A765");
            });

            modelBuilder.Entity<Puntuacion>(entity =>
            {
                entity.ToTable("Puntuacion");

                entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.Property(e => e.Puntuacion1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("Puntuacion");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Puntuacions)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("FK__Puntuacio__Id_Pe__5EDF0F2E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Puntuacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Puntuacio__Id_Us__5FD33367");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D105340771D1C6")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nick)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("Wishlist");

                entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");

                entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");

                entity.HasOne(d => d.IdPeliculaNavigation)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.IdPelicula)
                    .HasConstraintName("FK__Wishlist__Id_Pel__4AD81681");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Wishlist__Id_Usu__4BCC3ABA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
