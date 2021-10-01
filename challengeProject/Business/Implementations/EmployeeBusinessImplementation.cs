using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;
using System.Reflection;
using challengeProject.Repository;

namespace challengeProject.Business.Implementations
{
    public class EmployeeBusinessImplementation : IEmployeeBusiness
    {
        private readonly IRepository<Employee> _repository;
        public EmployeeBusinessImplementation(IRepository<Employee> repository)

        {
            _repository = repository;
        }
        public Employee Create(Employee employee)
        {
           
            return _repository.Create(employee);
        }

        public Employee FindByID(int employeeId)
        {
            return _repository.FindByID(employeeId);
        }

        public List<Project> FindProjectsByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> FindAll()
        {


            return _repository.FindAll();
        }

        public Employee Update(Employee employee)
        {
            
            return _repository.Update(employee);


        }


        public void Delete(int employeeId)
        {
            _repository.Delete(employeeId);

        }

      
        

    }
}
