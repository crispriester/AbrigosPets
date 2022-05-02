using Repository.Interfaces;
using Service.Interfaces;
using System;
using Xunit;
using Moq;
using Service.Services;
using Repository.Entities;
using Service.DTO;
using System.Collections.Generic;

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
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo foi inclu�do com sucesso!");

            //result
            _abrigosPetsRepository.Setup(x => x.Create(entidade));

            var retorno = (MensagemRetornoDto)_service.Create(dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Create_DeveGerarErro_CampoNaoInformado()
        {
            Setup();

            //Entrada
            var dto = new AbrigoDto
            {
                Nome = "Dom Labrador",
                Endereco = "",
                Telefone = 47966667866
            };

            var entidade = new AbrigosPetsEntity
            (
                "Dom Labrador",
                "",
                47966667866
            );

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("Todos os campos devem ser preenchidos.");

            //result
            _abrigosPetsRepository.Setup(x => x.Create(entidade));

            var retorno = (MensagemRetornoDto)_service.Create(dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Patch_DeveAtualizarAlgunsValores()
        {
            Setup();

            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Core de M�e",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Cora��o de M�e",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "S� da Cachorro",
                    "Roda mijada, Jaguara do Sul",
                    47984727465
                )
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo foi alterado com sucesso!");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(ListaAbrigosEntity[0].Id)).Returns(ListaAbrigosEntity[0]);

            var retorno = (MensagemRetornoDto)_service.Patch(ListaAbrigosEntity[0].Id, dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Patch_DeveGerarErro_TodasInformacoesModificadas()
        {
            Setup();

            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Core de M�e",
                Endereco = "Rua Cachorrada, Blumenau",
                Telefone = 47983727456
            };

            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Cora��o de M�e",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "S� da Cachorro",
                    "Roda mijada, Jaguara do Sul",
                    47984727465
                )
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("Apenas alguns dados devem ser alterados. Atualiza��o n�o realizada.");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(ListaAbrigosEntity[0].Id)).Returns(ListaAbrigosEntity[0]);

            var retorno = (MensagemRetornoDto)_service.Patch(ListaAbrigosEntity[0].Id, dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Patch_DeveGerarErro_NenhumaInformacaoModificada()
        {
            Setup();

            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Cora��o de M�e",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Cora��o de M�e",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "S� da Cachorro",
                    "Roda mijada, Jaguara do Sul",
                    47984727465
                )
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("Apenas alguns dados devem ser alterados. Atualiza��o n�o realizada.");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(ListaAbrigosEntity[0].Id)).Returns(ListaAbrigosEntity[0]);

            var retorno = (MensagemRetornoDto)_service.Patch(ListaAbrigosEntity[0].Id, dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Patch_DeveGerarErro_IdErrado()
        {
            Setup();

            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Core de M�e",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo n�o foi encontrado.");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(new Guid()));

            var retorno = (MensagemRetornoDto)_service.Patch(It.IsAny<Guid>(), dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
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
