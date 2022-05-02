using Repository.Entities;
using Repository.Interfaces;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Service.Services
{
    public class AbrigosPetsService : IAbrigosPetsService
    {
        private readonly IAbrigosPetsRepository _abrigosPetsRepository;

        public AbrigosPetsService(IAbrigosPetsRepository abrigosPetsRepository)
        {
            _abrigosPetsRepository = abrigosPetsRepository;
        }

        public (int, object) Create(AbrigoDto abrigoDto)
        {
            if (abrigoDto.Nome == null || abrigoDto.Endereco == null || abrigoDto.Telefone == 0)
            {
                return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"Todos os campos devem ser preenchidos."));
            }

            var abrigoEntity = AbrigosPetsEntity.DeAbrigoRetornoDtoParaAbrigosPetsEntity(abrigoDto.Nome, abrigoDto.Endereco, abrigoDto.Telefone);

            _abrigosPetsRepository.Create(abrigoEntity);

            return ((int)EnumRetornosHttp.Created, new MensagemRetornoDto($"O abrigo foi incluído com sucesso!"));
        }

        public (int, object) Read(Guid idAbrigo)
        {
            var entidade = _abrigosPetsRepository.GetById(idAbrigo);

            if (entidade != null)
            {
                return ((int)EnumRetornosHttp.Ok, AbrigoRetornoDto.DeAbrigosPetsEntityParaAbrigoRetornoDto(entidade));
            }

            return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"O abrigo não foi encontrado."));
        }


        public (int, object) Update(Guid idAbrigo, AbrigoDto abrigoDto)
        {
            var entidade = _abrigosPetsRepository.GetById(idAbrigo);

            if (entidade != null)
            {
                if (entidade.Nome == abrigoDto.Nome || entidade.Endereco == abrigoDto.Endereco || entidade.Telefone == abrigoDto.Telefone)
                {
                    return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"Todos os dados devem ser alterados. Atualização não realizada."));
                }

                entidade.Nome = abrigoDto.Nome;
                entidade.Endereco = abrigoDto.Endereco;
                entidade.Telefone = abrigoDto.Telefone;

                return ((int)EnumRetornosHttp.Ok, new MensagemRetornoDto($"O abrigo foi alterado com sucesso!"));
            }

            return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"O abrigo não foi encontrado."));
        }

        public (int, object) Patch(Guid idAbrigo, AbrigoDto abrigoDto)
        {
            var entidade = _abrigosPetsRepository.GetById(idAbrigo);

            if (entidade != null)
            {
                if ((entidade.Nome == abrigoDto.Nome && entidade.Endereco == abrigoDto.Endereco && entidade.Telefone == abrigoDto.Telefone) ||
                    (entidade.Nome != abrigoDto.Nome && entidade.Endereco != abrigoDto.Endereco && entidade.Telefone != abrigoDto.Telefone))
                {
                    return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"Apenas alguns dados devem ser alterados. Atualização não realizada."));
                }

                entidade.Nome = abrigoDto.Nome;
                entidade.Endereco = abrigoDto.Endereco;
                entidade.Telefone = abrigoDto.Telefone;

                return ((int)EnumRetornosHttp.Ok, new MensagemRetornoDto($"O abrigo foi alterado com sucesso!"));
            }

            return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"O abrigo não foi encontrado."));
        }

        public (int, object) Delete(Guid idAbrigo)
        {
            if (_abrigosPetsRepository.GetById(idAbrigo) == null)
            {
                return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"O abrigo não foi encontrado."));
            }

            _abrigosPetsRepository.Delete(idAbrigo);

            return ((int)EnumRetornosHttp.Ok, new MensagemRetornoDto($"O abrigo foi deletado com sucesso!"));
        }
    }
}