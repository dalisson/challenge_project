using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;

namespace challengeProject.Repository.Implementations
{
    public class MembershipRepositoryImplementation : IMembershipRepository
    {
        private MySQLContext _context;
        public MembershipRepositoryImplementation(MySQLContext context)

        {
            _context = context;
        }
        public Membership Create(Membership membership)
        {
            try
            {
                _context.Add(membership);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return membership;
        }
        public void Delete(Membership membership)
        {

            try
            {
                _context.Remove(membership);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
