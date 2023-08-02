using Cons.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;


namespace Cons_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //return "value";
            return Ok(new List<Paciente>()
            {
                new Paciente
                {
                    Id = 1,
                    Nome = "Pedro Paulo",
                    DataNascimento = new DateTime(1970,01,01)

                },
                new Paciente
                {
                   Id = 2,
                   Nome = "João Francisco",
                   DataNascimento = new DateTime(1980,02,02)

                }
            });
        }

        // GET: PacientesController
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <PacientesController>
        [HttpPut("(id")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <PacientesController>
        [HttpDelete("(id)")]
        public void Delete(int id)
        {
        }
    }
}
