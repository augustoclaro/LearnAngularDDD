using System;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using LearnAngular.Domain.Entities;

namespace LearnAngular.Data.EntityConfig
{
    public class ContatoConfig : EntityTypeConfiguration<Contato>
    {
        public ContatoConfig()
        {
            HasKey(c => c.IdContato);

            Property(c => c.NomeContato)
                .IsRequired();

            Property(c => c.TelefoneResidencial)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.TelefoneCelular)
                .IsRequired()
                .HasMaxLength(11);

            Property(c => c.DataInclusao)
                .IsRequired();
        }
    }
}
