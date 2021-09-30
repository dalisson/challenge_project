using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;


namespace challengeProject.Services
{
    public interface IMembershipService
    {
        Membership Create(Membership membership);
        void Delete(Membership membership);
    }
}
