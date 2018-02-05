using mvcinstance2.DataAccessLayer;
using mvcinstance2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcinstance2.ViewModels
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {

            SalesERPDAL sal = new SalesERPDAL();
            return sal.Employee.ToList();
        }
        public Employee SaveEmployee(Employee e )
        {
            SalesERPDAL sal = new SalesERPDAL();
            sal.Employee.Add(e);
            sal.SaveChanges();

            return e;
        }
}
}