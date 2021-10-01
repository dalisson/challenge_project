using challengeProject.Data.Converter.Contract;
using challengeProject.Data.VO;
using challengeProject.Model;
using System.Collections.Generic;
using System.Linq;

namespace challengeProject.Data.Converter.Implementation
{
    public class EmployeeConverter : IParser<EmployeeVO, Employee>, IParser<Employee, EmployeeVO>
    {
        public Employee Parse(EmployeeVO origin)
        {
            if (origin == null) return null;
            return new Employee
            {
                Id = origin.Id,
                primeiro_nome = origin.primeiro_nome,
                ultimo_nome = origin.ultimo_nome,
                telefone = origin.telefone,
                endereco = origin.endereco
            };
        }

        public List<Employee> Parse(List<EmployeeVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public EmployeeVO Parse(Employee origin)
        {
            if (origin == null) return null;
            return new EmployeeVO
            {
                Id = origin.Id,
                primeiro_nome = origin.primeiro_nome,
                ultimo_nome = origin.ultimo_nome,
                telefone = origin.telefone,
                endereco = origin.endereco
            };
        }

        public List<EmployeeVO> Parse(List<Employee> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
