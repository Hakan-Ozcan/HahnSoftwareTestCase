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
    public class OrdersRepository : IRepositoryDal<Orders>
    {
        private readonly Context _context;
        public OrdersRepository(Context context)
        {
            _context = context;
        }

        public void Add(Orders entity)
        {
            _context.Set<Orders>().Add(entity);
            _context.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            var order = _context.Set<Orders>().SingleOrDefault(x => x.OrderId == id);
            if (order != null)
            {
                _context.Set<Orders>().Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Orders> GetAll()
        {
            return _context.Set<Orders>().ToList();
        }

        public Orders GetByID(int id)
        {
            return _context.Set<Orders>().Where(x => x.OrderId == id).SingleOrDefault();
        }

        public void Update(Orders entity)
        {
            _context.Set<Orders>().Update(entity);
            _context.SaveChanges();
        }
    }
}
