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

        
        [HttpGet]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(List<ProjectVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Get()
        {
            return Ok(_projectBusiness.FindAll());
        }

       
        [HttpGet("{projectId}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ProjectVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Get(int projectId)
        {
            var project = _projectBusiness.FindByID(projectId);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ProjectVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Post([FromBody] ProjectVO project)
        {

            if (project == null)
            {
                return BadRequest();
            }
            var result = _projectBusiness.Create(project);
            return Ok(result);
        }
       
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        [ProducesResponseType((200), Type = typeof(ProjectVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Put([FromBody] ProjectVO project)
        {

            if (project == null)
            {
                return BadRequest();
            }
            return Ok(_projectBusiness.Update(project, project.Id));
        }
        [HttpDelete("{projectId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(int projectId)
        {

            _projectBusiness.Delete(projectId);
            return NoContent();
        }
    }
}
