using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;
using challengeProject.Model.Context;
using System.Reflection;

namespace challengeProject.Repository.Implementations
{
    public class EmployeeRepositoryImplementation : IEmployeeRepository
    {
        private MySQLContext _context;
        public EmployeeRepositoryImplementation(MySQLContext context)

        {
            _context = context;
        }
        public Employee Create(Employee employee)
        {
            try
            {
                _context.Add(employee);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
            return employee;
        }

        public Employee FindByID(int employeeId)
        {
            return _context.Employees.SingleOrDefault(p => p.Id.Equals(employeeId));
        }

        public List<Project> FindProjectsByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> FindAll()
        {


            return _context.Employees.ToList();
        }

        public Employee Update(Employee employee)
        {
            if(!employeeOnDb(employee.Id)) return null;

            var tempPerson = _context.Employees.SingleOrDefault(p => p.Id.Equals(employee.Id));

            try
            {
                _context.Entry(tempPerson).CurrentValues.SetValues(employee);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return employee;


        }


        public void Delete(int employeeId)
        {
            var tempPerson =  _context.Employees.SingleOrDefault(p => p.Id.Equals(employeeId));

            try
            {
                _context.Employees.Remove(tempPerson);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
    

        }

        //determines if employee is on database
        public bool employeeOnDb(int employeeId)
        {
            return _context.Employees.Any(p => p.Id.Equals(employeeId));
        }

        

    }
}
