using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;

namespace challengeProject.Services.Implementations
{
    public class MembershipServiceImplementation : IMembershipService
    {
        private MySQLContext _context;
        public MembershipServiceImplementation(MySQLContext context)

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
