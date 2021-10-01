﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challengeProject.Model;

namespace challengeProject.Repository
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);

        Employee FindByID(int employeeId);

        List<Project> FindProjectsByEmployee(int employeeId);

        List<Employee> FindAll();

        Employee Update(Employee employee);

        void Delete(int employeeId);
        bool employeeOnDb(int employeeId);
    }
}
