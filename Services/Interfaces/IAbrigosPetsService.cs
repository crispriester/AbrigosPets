using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAbrigosPetsService 
    {
        public (int, object) Create(AbrigoDto abrigoDto);

        public (int, object) Read(Guid id);

        public (int, object) Update(Guid id, AbrigoDto abrigoDto);

        public (int, object) Patch(Guid id, AbrigoDto abrigoDto);

        public (int, object) Delete(Guid id);
    }
}
