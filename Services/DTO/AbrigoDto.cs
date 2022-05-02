using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class AbrigoDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public long Telefone { get; set; } = 0;
    }
}
