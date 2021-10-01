using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;
using challengeProject.Repository;

namespace challengeProject.Business.Implementations
{
    public class ProjectBusinessImplementation : IProjectBusiness
    {
        private readonly IProjectRepository _repository;
        public ProjectBusinessImplementation(IProjectRepository repository)

        {
            _repository = repository;
        }
        public Project Create(Project project)
        {
            
            return _repository.Create(project);
        }

        public Project FindByID(int projectId)
        {
            return _repository.FindByID(projectId);
        }

        public List<Employee> FindEmployeesByProject(int projetoId)
        {
            throw new NotImplementedException();
        }

        public List<Project> FindAll()
        {
            return _repository.FindAll();
        }

        public Project Update(Project project)
        {
            
            return _repository.Update(project);
        }

        public void Delete(int projectId)
        {
            _repository.Delete(projectId);
            
        }

        

    }
}
