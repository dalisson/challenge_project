using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;

namespace challengeProject.Business
{
    public interface IProjectBusiness
    {
        Project Create(Project project);

        Project FindByID(int projectId);

        List<Project> FindAll();

        Project Update(Project project);

        void Delete(int projectId);
    }
}
