using System;
using System.Collections.Generic;

namespace LearnAngular.Domain.Entities
{
    public class Categoria
    {
        public Guid IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public DateTime DataInclusao { get; set; }

        public virtual ICollection<Contato> Contato { get; set; }
    }
}
