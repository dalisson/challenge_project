using System.Collections.Generic;
using challengeProject.Data.VO;

namespace challengeProject.Business
{
    public interface IEmployeeBusiness
    {
        EmployeeVO Create(EmployeeVO employee);

        EmployeeVO FindByID(int employeeId);


        List<EmployeeVO> FindAll();

        EmployeeVO Update(EmployeeVO employee);

        void Delete(int employeeId);
    }
}
