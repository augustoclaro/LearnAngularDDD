using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using LearnAngular.Domain.Entities;

namespace LearnAngular.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(c => c.IdUsuario);

            Property(c => c.NomeUsuario)
                .IsRequired();

            Property(c => c.Login)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(32);

            Property(c => c.DataInclusao)
                .IsRequired();


        }
    }
}
