using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Business;

namespace challengeProject.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ProjectController : ControllerBase
    {
        

        private readonly ILogger<ProjectController> _logger;
        private IProjectBusiness _projectBusiness;


        public ProjectController(ILogger<ProjectController> logger, IProjectBusiness projectService)
        {
            _logger = logger;
            _projectBusiness = projectService;
        }

        //retornar todos os empregados
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_projectBusiness.FindAll());
        }

        //retorna empregado por id
        [HttpGet("{projectId}")]
        public IActionResult Get(int projectId)
        {
            var project = _projectBusiness.FindByID(projectId);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        //persistir novo empregado na tabela
        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {

            if (project == null)
            {
                return BadRequest();
            }
            return Ok(_projectBusiness.Create(project));
        }
        //atualizar empregado na tabela
        [HttpPut]
        public IActionResult Put([FromBody] Project project)
        {

            if (project == null)
            {
                return BadRequest();
            }
            return Ok(_projectBusiness.Update(project));
        }
        [HttpDelete("{projectId}")]
        public IActionResult Delete(int projectId)
        {

            _projectBusiness.Delete(projectId);
            return NoContent();
        }
    }
}
