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
    public class ProductRepository : IProductDal
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }
        public void Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
            _context.SaveChanges();
        }

        public void DeleteByID(int id)
        {
            var order = _context.Set<Product>().SingleOrDefault(x => x.ProductId == id);
            if (order != null)
            {
                _context.Set<Product>().Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product GetByID(int id)
        {
            return _context.Set<Product>().Where(x => x.ProductId == id).SingleOrDefault();
        }

        public void Update(Product entity)
        {
            _context.Set<Product>().Update(entity);
            _context.SaveChanges();
        }
    }
}
