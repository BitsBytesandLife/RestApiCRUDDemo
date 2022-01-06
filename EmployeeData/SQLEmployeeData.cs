using RestApiCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    public class SQLEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SQLEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
            
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee EditEmployee(Employee employee)
        {
            var currentEmployee = _employeeContext.Employees.SingleOrDefault(x => x.Id == employee.Id);
            if (currentEmployee != null)
            {
                currentEmployee.Name = employee.Name;
                _employeeContext.Employees.Update(currentEmployee);
                _employeeContext.SaveChanges();
            }
            return currentEmployee;
        }
        public Employee GetEmployee(Guid id)
        { 
          return _employeeContext.Employees.SingleOrDefault(x => x.Id == id);
          //Or use the Find
          //var employee = _employeeContext.Find(id);
          //return employee;
        }

        public List<Employee> GetEmployees()
        {
          return  _employeeContext.Employees.ToList();
        }
    }
}
