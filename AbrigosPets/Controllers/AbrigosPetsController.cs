using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Entities;
using Repository.Repositories;
using Service.DTO;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrigosPets.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AbrigosPetsController : ControllerBase
    {

        private readonly IAbrigosPetsService _abrigosPetsService;

        public AbrigosPetsController(IAbrigosPetsService abrigosPetsService)
        {
            _abrigosPetsService = abrigosPetsService;
        }

        [HttpPost()]
        public IActionResult Post([FromBody] AbrigoDto abrigoDto)
        {
            var (status, retorno) = _abrigosPetsService.Create(abrigoDto);

            return StatusCode(status, retorno);
            
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            var (status, retorno) = _abrigosPetsService.Read(id);

            return StatusCode(status, retorno);
        }


        [HttpPut]
        public IActionResult Put(Guid id)
        {
            var (status, retorno) = _abrigosPetsService.Update(id);

            return StatusCode(status, retorno);
        }

        [HttpPatch]
        public IActionResult Patch(Guid id)
        {
            var (status, retorno) = _abrigosPetsService.Patch(id);

            return StatusCode(status, retorno);
        }


        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            var (status, retorno) = _abrigosPetsService.Delete(id);

            return StatusCode(status, retorno);         
        }

    }
}

