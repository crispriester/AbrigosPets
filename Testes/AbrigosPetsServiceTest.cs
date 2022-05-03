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
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo foi incluído com sucesso!");

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
                Endereco = "Bla",
                Telefone = 0
            };

            var entidade = new AbrigosPetsEntity
            (
                "Dom Labrador",
                "Bla",
                0
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
                Nome = "Core de Mãe",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Coração de Mãe",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "Só da Cachorro",
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
                Nome = "Core de Mãe",
                Endereco = "Rua Cachorrada, Blumenau",
                Telefone = 47983727456
            };

            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Coração de Mãe",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "Só da Cachorro",
                    "Roda mijada, Jaguara do Sul",
                    47984727465
                )
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("Apenas alguns dados devem ser alterados. Atualização não realizada.");

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
                Nome = "Coração de Mãe",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Coração de Mãe",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "Só da Cachorro",
                    "Roda mijada, Jaguara do Sul",
                    47984727465
                )
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("Nenhum valor é diferente dos atuais. Atualização não realizada.");

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
            var id = new Guid();

            var dto = new AbrigoDto()
            {
                Nome = "Core de Mãe",
                Endereco = "Rua cachorrada, Blumenau",
                Telefone = 47984727456
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo não foi encontrado.");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(id));

            var retorno = (MensagemRetornoDto)_service.Patch(id, dto).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Read_DevePegarPorId()
        {
            Setup();

            //Entrada
            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Coração de Mãe",
                    "Rua cachorrada, Blumenau",
                    47984727456
                )
            };

            //Saida
            var retornoEsperado = AbrigoRetornoDto.DeAbrigosPetsEntityParaAbrigoRetornoDto(ListaAbrigosEntity[0]);

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(ListaAbrigosEntity[0].Id)).Returns(ListaAbrigosEntity[0]);

            var retorno = (AbrigoRetornoDto)_service.Read(ListaAbrigosEntity[0].Id).Item2;

            Assert.Equal(retornoEsperado.Id, retorno.Id);
        }

        [Fact]
        public void Read_DeveGerarErro_IdInvalido()
        {
            Setup();

            //Entrada
            var id = new Guid();

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo não foi encontrado.");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(id));

            var retorno = (MensagemRetornoDto)_service.Read(id).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Delete_DeveDeletar()
        {
            Setup();

            //Entrada

            var entidade = new AbrigosPetsEntity
            (
                "Dom Labrador",
                "Rua Divisa, Rio do Cachorros",
                47966667866
            );

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo foi deletado com sucesso!");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(entidade.Id)).Returns(entidade);

            var retorno = (MensagemRetornoDto)_service.Delete(entidade.Id).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);

        }

        [Fact]
        public void Delete_DeveGerrarErro_IdInvalido()
        {
            Setup();

            //Entrada
            var id = new Guid();

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo não foi encontrado.");

            //result
            _abrigosPetsRepository.Setup(x => x.GetById(id));

            var retorno = (MensagemRetornoDto)_service.Delete(id).Item2;

            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);

        }

        [Fact]
        public void Update_DeveAtualizar()
        {
            Setup();
            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Patinhas Pet",
                Endereco = "Rua Arcurra, Itajai",
                Telefone = 47988305768
            };
            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Coração de Mãe",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "Só da Cachorro",
                    "Roda mijada, Jaguara do Sul",
                    47984727465
                )
            };
            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo foi alterado com sucesso!");
            //result
            _abrigosPetsRepository.Setup(x => x.GetById(ListaAbrigosEntity[0].Id)).Returns(ListaAbrigosEntity[0]);
            var retorno = (MensagemRetornoDto)_service.Update(ListaAbrigosEntity[0].Id, dto).Item2;
            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Update__DeveGerarErro_IdErrado()
        {
            Setup();
            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Patinhas Pet",
                Endereco = "Rua Arcura, Itajai",
                Telefone = 47984727456
            };
            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("O abrigo não foi encontrado.");
            //result
            _abrigosPetsRepository.Setup(x => x.GetById(new Guid()));
            var retorno = (MensagemRetornoDto)_service.Patch(It.IsAny<Guid>(), dto).Item2;
            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }

        [Fact]
        public void Update_DeveRetornarErro()
        {
            Setup();
            //Entrada
            var dto = new AbrigoDto()
            {
                Nome = "Patinhas et",
                Endereco = "Rua Arcura, Itajai",
                Telefone = 47984727456
            };
            var ListaAbrigosEntity = new List<AbrigosPetsEntity>()
            {
                 new AbrigosPetsEntity
                (
                    "Coração de Mãe",
                    "Rua cachorrada, Blumenau",
                    47984727456
                ),
                 new AbrigosPetsEntity
                (
                    "Só da Cachorro",
                    "Roda mijada, Jaguara do Sul",
                    47984727465
                )
            };

            //Saida
            var mensagemEsperadaRetorno = new MensagemRetornoDto("Todos os dados devem ser alterados. Atualização não realizada.");
            
            //result
            _abrigosPetsRepository.Setup(x => x.GetById(ListaAbrigosEntity[0].Id)).Returns(ListaAbrigosEntity[0]);
            var retorno = (MensagemRetornoDto)_service.Update(ListaAbrigosEntity[0].Id, dto).Item2;
            Assert.Equal(mensagemEsperadaRetorno.Mensagem, retorno.Mensagem);
        }
    }
}
