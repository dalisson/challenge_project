using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Business;
using challengeProject.Data.VO;
using challengeProject.Hypermedia.Filters;
using Microsoft.AspNetCore.Authorization;

namespace challengeProject.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class EmployeeController : ControllerBase
    {
        

        private readonly ILogger<EmployeeController> _logger;
        private IEmployeeBusiness _employeeBusiness;
        private IMembershipBusiness _membershipBusiness;


        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeBusiness employeeService, IMembershipBusiness membershipService)
        {
            _logger = logger;
            _employeeBusiness = employeeService;
            _membershipBusiness = membershipService;
        }

        //retornar todos os empregados
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<EmployeeVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_employeeBusiness.FindAll());
        }

        //retorna empregado por id
        [HttpGet("{employeeId}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(EmployeeVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Get(int employeeId)
        {
            var employee = _employeeBusiness.FindByID(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        //persistir novo empregado na tabela
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(EmployeeVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Post([FromBody] EmployeeVO employee)
        {

            if (employee == null)
            {
                return BadRequest();
            }
            return Ok(_employeeBusiness.Create(employee));
        }
        
        //atualizar empregado na tabela
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(EmployeeVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] EmployeeVO employee)
        {

            if (employee == null)
            {
                return BadRequest();
            }
            return Ok(_employeeBusiness.Update(employee, employee.Id));
        }
        [HttpDelete("{employeeId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int employeeId)
        {

            _employeeBusiness.Delete(employeeId);
            return NoContent();
        }

        [HttpPost("addtoproject")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(Membership))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult AddToProject([FromBody] Membership membership)
        {

            if (membership == null)
            {
                return BadRequest();
            }
            return Ok(_membershipBusiness.Create(membership));
        }

        [HttpDelete("removefromproject")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult RemoveFromProject([FromBody] Membership membership)
        {

            if (membership == null)
            {
                return BadRequest();
            }
            _membershipBusiness.Delete(membership);
            return NoContent();
        }
    }
}
