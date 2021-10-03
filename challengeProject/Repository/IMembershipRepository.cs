using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;


namespace challengeProject.Repository
{
    public interface IMembershipRepository

    {
        Membership Create(Membership membership);
        void Delete(Membership membership);

        public bool isManager(Membership membership);
    }
}
