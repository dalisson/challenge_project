using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Data.Converter.Implementation;
using challengeProject.Data.VO;
using challengeProject.Model;
using challengeProject.Model.Context;
using challengeProject.Repository;

namespace challengeProject.Business.Implementations
{
    public class ProjectBusinessImplementation : IProjectBusiness
    {
        private readonly IRepository<Project> _repository;
        private readonly ProjectConverter _converter;
        public ProjectBusinessImplementation(IRepository<Project> repository)

        {
            _repository = repository;
            _converter = new ProjectConverter();

        }
        public ProjectVO Create(ProjectVO project)
        {
            
            return _converter.Parse(_repository.Create(_converter.Parse(project)));
        }

        public ProjectVO FindByID(int projectId)
        {
            return _converter.Parse(_repository.FindByID(projectId));
        }

        public List<ProjectVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public ProjectVO Update(ProjectVO project, int id)
        {
            
            return _converter.Parse(_repository.Update(_converter.Parse(project), id));
        }

        public void Delete(int projectId)
        {
            _repository.Delete(projectId);
            
        }

        

    }
}
