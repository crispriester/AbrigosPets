using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public class AbrigoRetornoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Endereco { get; set; }

        public static AbrigoRetornoDto DeAbrigosPetsEntityParaAbrigoRetornoDto(AbrigosPetsEntity abrigosPetsEntity)
        {
            return new AbrigoRetornoDto
            {
                Id = abrigosPetsEntity.Id,
                Nome = abrigosPetsEntity.Nome,
                Endereco = abrigosPetsEntity.Endereco,
                Telefone = abrigosPetsEntity.Telefone
            };
        }
    }
}
