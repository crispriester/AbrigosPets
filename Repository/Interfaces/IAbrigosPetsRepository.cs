using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IAbrigosPetsRepository
    {
        public void Create(AbrigosPetsEntity abrigosPetsEntity);
        public AbrigosPetsEntity GetById(Guid idAbrigo);
        public void Delete(Guid idAbrigo);
    }
}
