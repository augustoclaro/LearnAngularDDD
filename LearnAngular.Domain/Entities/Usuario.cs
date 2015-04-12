using System;

namespace LearnAngular.Domain.Entities
{
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime DataInclusao { get; set; }
    }
}
