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
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> entity)
        {
            entity.HasKey(e => e.IdComentario);

            entity.ToTable("Comentario");

            entity.Property(e => e.IdComentario).ValueGeneratedNever();

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.IdPublicacionNavigation)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdPublicacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Publicacion");

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comentario_Usuario");
        }
    }
}
