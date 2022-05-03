using Moq;
using Repository.Entities;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class AbrigosPetsEntityTest
    {

        [Fact]
        public void AbrigosPetsEntity_Test()
        {
            //Entrada
            var id = Guid.NewGuid();

            var dto = new AbrigoDto()
            {
                Nome = "Core de Mãe",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };
            
            //result
            var retorno = new AbrigosPetsEntity
            (
                dto.Nome,
                dto.Endereco,
                dto.Telefone
            );

            retorno.Id = id;

            Assert.Equal(dto.Nome, retorno.Nome);
            Assert.Equal(dto.Endereco, retorno.Endereco);
            Assert.Equal(dto.Telefone, retorno.Telefone);
            Assert.Equal(id, retorno.Id);
        }

        [Fact]
        public void AbrigosPetsEntity_DeveRetornarDto()
        {
            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Core de Mãe",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            var entidade = new AbrigosPetsEntity
            (
                dto.Nome,
                dto.Endereco,
                dto.Telefone
            );

            //Saida
            var retornoEsperado = new AbrigoRetornoDto()
            {
                Id = entidade.Id,
                Nome = "Core de Mãe",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            //result
            Assert.Equal(retornoEsperado.Nome, entidade.Nome);
            Assert.Equal(retornoEsperado.Endereco, entidade.Endereco);
            Assert.Equal(retornoEsperado.Telefone, entidade.Telefone);
            Assert.Equal(retornoEsperado.Id, entidade.Id);
        }
    }
}
