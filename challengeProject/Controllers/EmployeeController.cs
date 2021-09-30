using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Services;

namespace challengeProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        

        private readonly ILogger<EmployeeController> _logger;
        private IEmployeeService _employeeService;


        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        //retornar todos os empregados
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeService.FindAll());
        }

        //retorna empregado por id
        [HttpGet("{empregadoId}")]
        public IActionResult Get(int empregadoId)
        {
            var empregado = _employeeService.FindByID(empregadoId);
            if (empregado == null)
            {
                return NotFound();
            }
            return Ok(empregado);
        }

        //persistir novo empregado na tabela
        [HttpPost]
        public IActionResult Post([FromBody] Employee empregado)
        {

            if (empregado == null)
            {
                return BadRequest();
            }
            return Ok(_employeeService.Create(empregado));
        }
        //atualizar empregado na tabela
        [HttpPut]
        public IActionResult Put([FromBody] Employee empregado)
        {

            if (empregado == null)
            {
                return BadRequest();
            }
            return Ok(_employeeService.Update(empregado));
        }
        [HttpDelete("{empregadoId}")]
        public IActionResult Delete(int empregadoId)
        {

            _employeeService.Delete(empregadoId);
            return NoContent();
        }
    }
}
