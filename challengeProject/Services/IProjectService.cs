using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;

namespace challengeProject.Services
{
    public interface IProjectService
    {
        Project Create(Project project);

        Project FindByID(int projectId);

        List<Employee> FindEmployeesByProject(int projetoId);

        List<Project> FindAll();

        Project Update(Project project);

        void Delete(int projectId);
    }
}
