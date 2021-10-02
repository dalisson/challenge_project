using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Data.VO;
using challengeProject.Model;

namespace challengeProject.Business
{
    public interface IProjectBusiness
    {
        ProjectVO Create(ProjectVO project);

        ProjectVO FindByID(int projectId);

        List<ProjectVO> FindAll();

        ProjectVO Update(ProjectVO project, int id);

        void Delete(int projectId);
    }
}
