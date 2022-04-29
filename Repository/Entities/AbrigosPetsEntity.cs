using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class AbrigosPetsEntity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Telefone { get; set; }
        public Guid Id { get; set; }

        public AbrigosPetsEntity(string nome, string endereco, int telefone)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}
