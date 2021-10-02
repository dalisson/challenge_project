using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;
using challengeProject.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace challengeProject.Repository.Implementations
{
    public class EmployeeRepositoryImplementation : GenericRepository<Employee>
    {
        private MySQLContext _context;
        private DbSet<Employee> dataset;
        public EmployeeRepositoryImplementation(MySQLContext context) : base(context)
        {
            _context = context;
            dataset = _context.Set<Employee>();
        }

        public Membership AddToProject(Membership membership)
        {
            MembershipRepositoryImplementation memship = new MembershipRepositoryImplementation(_context);

            return memship.Create(membership);
        }
        
    }
}
