using Repository.Interfaces;
using Service.Interfaces;
using System;
using Xunit;
using Moq;
using Service.Services;
using Repository.Entities;
using Service.DTO;

namespace Testes
{
    public class AbrigosPetsServiceTest
    {
        private Mock<IAbrigosPetsRepository> _abrigosPetsRepository;
        private IAbrigosPetsService _service;

        private void Setup()
        {
            _abrigosPetsRepository = new Mock<IAbrigosPetsRepository>();
            _service = new AbrigosPetsService(_abrigosPetsRepository.Object);
        }

        [Fact]
        public void Create_DeveCriar()
        {
            Setup();

            //Entrada
            var dto = new AbrigoDto
            {
                Nome = "Dom Labrador",
                Endereco = "Rua Divisa, Rio do Cachorros",
                Telefone = 47966667866
            };

            var entidade = new AbrigosPetsEntity
            (
                "Dom Labrador",
                "Rua Divisa, Rio do Cachorros",
                47966667866
            );

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo foi incluído com sucesso!");

            //result
            _abrigosPetsRepository.Setup(x => x.Create(entidade));

            var retorno = (MensagemRetornoDto)_service.Create(dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno, retorno);
        }

        [Fact]
        public void Patch_DeveAtualizarAlgunsValores()
        {
            Setup();

            
        }

        [Fact]
        public void Update_DeveAtualizar()
        {
            Setup();

        }

        [Fact]
        public void Read_DevePegarPorId()
        {
            Setup();

        }

        [Fact]
        public void Delete_DeveDeletar()
        {
            Setup();

        }
    }
}
