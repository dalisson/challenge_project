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
    public class ProjectController : ControllerBase
    {
        

        private readonly ILogger<ProjectController> _logger;
        private IProjectService _projectService;


        public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
        {
            _logger = logger;
            _projectService = projectService;
        }

        //retornar todos os empregados
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_projectService.FindAll());
        }

        //retorna empregado por id
        [HttpGet("{projectId}")]
        public IActionResult Get(int projectId)
        {
            var project = _projectService.FindByID(projectId);
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
            return Ok(_projectService.Create(project));
        }
        //atualizar empregado na tabela
        [HttpPut]
        public IActionResult Put([FromBody] Project project)
        {

            if (project == null)
            {
                return BadRequest();
            }
            return Ok(_projectService.Update(project));
        }
        [HttpDelete("{projectId}")]
        public IActionResult Delete(int projectId)
        {

            _projectService.Delete(projectId);
            return NoContent();
        }
    }
}
