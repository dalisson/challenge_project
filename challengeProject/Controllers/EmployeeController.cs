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
        [HttpGet("{employeeId}")]
        public IActionResult Get(int employeeId)
        {
            var employee = _employeeService.FindByID(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //persistir novo empregado na tabela
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {

            if (employee == null)
            {
                return BadRequest();
            }
            return Ok(_employeeService.Create(employee));
        }
        //atualizar empregado na tabela
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {

            if (employee == null)
            {
                return BadRequest();
            }
            return Ok(_employeeService.Update(employee));
        }
        [HttpDelete("{employeeId}")]
        public IActionResult Delete(int employeeId)
        {

            _employeeService.Delete(employeeId);
            return NoContent();
        }
    }
}
