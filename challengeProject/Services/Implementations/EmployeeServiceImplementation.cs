using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;

namespace challengeProject.Services.Implementations
{
    public class EmployeeServiceImplementation : IEmployeeService
    {
        public Employee Create(Employee employee)
        {
            return employee;
        }

        public Employee FindByID(int employeeId)
        {
            return new Employee
            {
                id_empregado = 1,
                primeiro_nome = "dalisson",
                ultimo_nome = "figueiredo",
                telefone = 42,
                endereco = "dalissonfigueiredo@gmail.com"
            };
        }

        public List<Project> FindProjectsByEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<Employee> FindAll()
        {

            List<Employee> empregados = new List<Employee>();
            for (int i = 0; i < 8; i++)
            {
                Employee empregado = MockEmployee(i);
                empregados.Add(empregado);
            };
            return empregados;
        }

        public Employee Update(Employee empregado)
        {
            return empregado;
        }


        public void Delete(int employeeId)
        {

        }

        private Employee MockEmployee(int i)
        {
            return new Employee
            {
                id_empregado = i,
                primeiro_nome = "dalisson" + i,
                ultimo_nome = "number" + i,
                telefone = i + 42,
                endereco = "ohno@gmail.com"
            };
        }
    }
}
