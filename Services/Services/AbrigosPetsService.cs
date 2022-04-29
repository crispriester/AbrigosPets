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
            foreach (var propriedade in abrigoDto.GetType().GetProperties())
            {
                if (propriedade.GetValue(abrigoDto) == null)
                {
                    return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"O campo {propriedade.Name} deve ser preenchido."));
                }
            }

            //_abrigosPetsRepository.Create(abrigoDto.Nome, abrigoDto.Endereco, abrigoDto.Telefone);

            return ((int)EnumRetornosHttp.Created, new MensagemRetornoDto($"O abrigo foi incluído com sucesso!"));
        }

        public (int, object) Read(Guid idAbrigo)
        {
            if (idAbrigo.Equals(""))
            {
                return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"O campo ID deve ser preenchido."));
            }

            //var entidade = _abrigosPetsRepository.GetById(idAbrigo);

            //if (entidade != null)
            //{
            //    return ((int)EnumRetornosHttp.Ok, AbrigoRetornoDto.DeAbrigosPetsEntityParaAbrigoRetornoDto(entidade));
            //}

            return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"O abrigo não foi encontrado."));
        }

        public (int, object) Update(Guid idAbrigo)
        {
            if (idAbrigo.Equals(""))
            {
                return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"O campo ID deve ser preenchido."));
            }

            //var entidade = _abrigosPetsRepository.GetById(idAbrigo);

            //if (entidade != null)
            //{
            //    return ((int)EnumRetornosHttp.Ok, AbrigoRetornoDto.DeAbrigosPetsEntityParaAbrigoRetornoDto(entidade));
            //}

            return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"O abrigo não foi encontrado."));
        }

        public (int, object) Patch(Guid idAbrigo)
        {
            if (idAbrigo.Equals(""))
            {
                return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"O campo ID deve ser preenchido."));
            }

            //var entidade = _abrigosPetsRepository.GetById(idAbrigo);

            //if (entidade != null)
            //{
            //    return ((int)EnumRetornosHttp.Ok, AbrigoRetornoDto.DeAbrigosPetsEntityParaAbrigoRetornoDto(entidade));
            //}

            return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"Abrigo não encontrado."));
        }

        public (int, object) Delete(Guid idAbrigo)
        {
            if (idAbrigo.Equals(""))
            {
                return ((int)EnumRetornosHttp.BadRequest, new MensagemRetornoDto($"O campo ID deve ser preenchido."));
            }

            //if (_abrigosPetsRepository.GetById(idAbrigo) == null)
            //{
            //    return ((int)EnumRetornosHttp.NotFound, new MensagemRetornoDto($"Abrigo não encontrado."));
            //}

            //_abrigosPetsRepository.Delete(idAbrigo);

            return ((int)EnumRetornosHttp.Ok, new MensagemRetornoDto($"O abrigo foi deletado."));
        }
    }
}
