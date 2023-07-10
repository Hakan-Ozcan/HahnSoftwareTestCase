using ApplicationLayer.Abstract;
using DomainLayer.Entities;
using InfrastructureLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employee;
        public EmployeeManager(IEmployeeDal employee)
        {
            _employee = employee;
        }
        public void EmployeeAdd(Employee employee)
        {
             _employee.Add(employee);
        }

        public void EmployeeDeleteByID(short id)
        {
           _employee.DeleteByID(id);
        }

        public Employee EmployeeGetByID(short id)
        {
            return _employee.GetByID(id);
        }

        public IEnumerable<Employee> EmployeeGetList()
        {
            return _employee.GetAll();
        }

        public void EmployeeUpdate(Employee employee)
        {
            _employee.Update(employee);
        }
    }
}
