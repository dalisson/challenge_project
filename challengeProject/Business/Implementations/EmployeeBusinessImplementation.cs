using System.Collections.Generic;
using challengeProject.Model;
using challengeProject.Repository;
using challengeProject.Data.VO;
using challengeProject.Data.Converter.Implementation;

namespace challengeProject.Business.Implementations
{
    public class EmployeeBusinessImplementation : IEmployeeBusiness
    {
        private readonly IRepository<Employee> _repository;

        private readonly EmployeeConverter _converter;
        public EmployeeBusinessImplementation(IRepository<Employee> repository)

        {
            _repository = repository;
            _converter = new EmployeeConverter();
        }
        public EmployeeVO Create(EmployeeVO employee)
        {
           
            return _converter.Parse(_repository.Create(_converter.Parse(employee)));
        }

        public EmployeeVO FindByID(int employeeId)
        {
            return _converter.Parse(_repository.FindByID(employeeId));
        }

        

        public List<EmployeeVO> FindAll()
        {


            return _converter.Parse(_repository.FindAll());
        }

        public EmployeeVO Update(EmployeeVO employee)
        {
            
            return _converter.Parse(_repository.Update(_converter.Parse(employee)));


        }


        public void Delete(int employeeId)
        {
            _repository.Delete(employeeId);

        }

      
        

    }
}
