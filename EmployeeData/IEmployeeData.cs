using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCRUDDemo.EmployeeData
{
    interface IEmployeeData
    {

        List<Employee> GetEmployees();
    }
}
