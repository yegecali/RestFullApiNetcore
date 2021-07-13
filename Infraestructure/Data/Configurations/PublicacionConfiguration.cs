using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Configurations
{
    public class PublicacionConfiguration : IEntityTypeConfiguration<Publicacion>
    {
        public void Configure(EntityTypeBuilder<Publicacion> entity)
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("IdPublicacion");
            entity.ToTable("Publicacion");

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.Property(e => e.Imagen)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Publicacions)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Publicacion_Usuario");
        }
    }
}
