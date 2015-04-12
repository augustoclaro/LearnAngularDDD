using System;

namespace LearnAngular.Domain.Entities
{
    public class Contato
    {
        public Guid IdContato { get; set; }
        public string NomeContato { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }
        public Guid IdCategoria { get; set; }
        public DateTime DataInclusao { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
