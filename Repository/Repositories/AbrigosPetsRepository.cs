using Repository.Interfaces;
﻿using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AbrigosPetsRepository : IAbrigosPetsRepository
    {
        public List<AbrigosPetsEntity> ListaAbrigosEntity;

        public AbrigosPetsRepository()
        {
            ListaAbrigosEntity = new List<AbrigosPetsEntity>()
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
                ),
                  new AbrigosPetsEntity
                (
                    "Viralata Caramelo",
                    "Rua cachorrada, Rio do Cachorros",
                    47966666666
                ),
                   new AbrigosPetsEntity
                (
                    "Serumaninho",
                    "Rua dos vapecas, Caramelo",
                    47984724278
                ),
                    new AbrigosPetsEntity
                (
                    "Felinos",
                    "Rua Gataiada, Garfield",
                    47973647563
                ),
            };
        }

        public List<AbrigosPetsEntity> Create(object propriedade)
        {
            ListaAbrigosEntity.Add((AbrigosPetsEntity)propriedade);
            return ListaAbrigosEntity;
        }

        public object Delete(Guid idAbrigo)
        {
            var entidade = ListaAbrigosEntity.Find(x => x.Id == idAbrigo);

            return entidade;
        }

        public object Patch(Guid idAbrigo)
        {
            var entidade = ListaAbrigosEntity.Find(x => x.Id == idAbrigo);

            return entidade;
        }

        public object Read(Guid idAbrigo)
        {
            var entidade = ListaAbrigosEntity.Find(x => x.Id == idAbrigo);

            return entidade;
        }

        public object Update(Guid idAbrigo)
        {
            var entidade = ListaAbrigosEntity.Find(x => x.Id == idAbrigo);

            return entidade;
        }
    }
}
