using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;

namespace challengeProject.Repository.Implementations
{
    public class ProjectRepositoryImplementation : IProjectRepository
    {
        private MySQLContext _context;
        public ProjectRepositoryImplementation(MySQLContext context)

        {
            _context = context;
        }
        public Project Create(Project project)
        {
            try
            {
                _context.Add(project);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return project;
        }

        public Project FindByID(int projectId)
        {
            return _context.Projects.SingleOrDefault(p => p.Id.Equals(projectId));
        }

        public List<Employee> FindEmployeesByProject(int projetoId)
        {
            throw new NotImplementedException();
        }

        public List<Project> FindAll()
        {
            return _context.Projects.ToList();
        }

        public Project Update(Project project)
        {
            if (!projectOnDb(project.Id)) return null;

            var tempProject = _context.Projects.SingleOrDefault(p => p.Id.Equals(project.Id));

            try
            {
                _context.Entry(tempProject).CurrentValues.SetValues(project);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return project;
        }

        public void Delete(int projectId)
        {
            var tempProject = _context.Projects.SingleOrDefault(p => p.Id.Equals(projectId));

            try
            {
                _context.Remove(tempProject);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public bool projectOnDb(int projectId)
        {
            return _context.Projects.Any(p => p.Id.Equals(projectId));
        }

    }
}
