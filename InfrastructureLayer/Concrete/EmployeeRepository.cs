using DomainLayer.Entities;
using InfrastructureLayer.Abstract;
using InfrastructureLayer.SqlContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Concrete
{
    public class EmployeeRepository : IRepositoryDal<Employee>
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public void Add(Employee entity)
        {
            _context.Set<Employee>().Add(entity);
            _context.SaveChanges();
        }

     

        public void DeleteByID(int id)
        {
            var order = _context.Set<Employee>().SingleOrDefault(x => x.EmployeeId == id);
            if (order != null)
            {
                _context.Set<Employee>().Remove(order);
                _context.SaveChanges();
            }
        }

     

        public IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().ToList();
        }

        public Employee GetByID(int id)
        {
            return _context.Set<Employee>().Where(x => x.EmployeeId == id).SingleOrDefault();
        }

        public void Update(Employee entity)
        {
            _context.Set<Employee>().Update(entity);
            _context.SaveChanges();
        }
    }
}
