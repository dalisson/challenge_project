using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;
using challengeProject.Repository;

namespace challengeProject.Business.Implementations
{
    public class MembershipBusinessImplementation : IMembershipBusiness
    {
        private readonly IMembershipRepository _repository;
        public MembershipBusinessImplementation(IMembershipRepository repository)

        {
            _repository = repository;
        }
        public Membership Create(Membership membership)
        {
            
            return _repository.Create(membership);
        }
        public void Delete(Membership membership)
        {
            //employee must no longer be a manager before he can be untangled from project
            if (!_repository.isManager(membership))
            {
                _repository.Delete(membership);
            }
            
        }
        
    }
}
