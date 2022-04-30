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
        public List<AbrigosPetsEntity> Create(object propriedade);
        public object Read(Guid idAbrigo);
        public object Update(Guid idAbrigo);
        public object Patch(Guid idAbrigo);
        public object Delete(Guid idAbrigo);
    }
}
