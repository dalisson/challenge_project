using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;
using MySql.Data.MySqlClient;

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

        //nao posso remover manager
        public bool isManager(Membership membership)
        {
            var result = (from u in _context.Projects
                          where u.Id == membership.id_projeto && u.gerente == membership.id_empregado
                          select u.Id).Any();
            return result;
        }
    }
}
