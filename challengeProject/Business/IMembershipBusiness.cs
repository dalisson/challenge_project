using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;


namespace challengeProject.Business
{
    public interface IMembershipBusiness
    {
        Membership Create(Membership membership);
        void Delete(Membership membership);
    }
}
