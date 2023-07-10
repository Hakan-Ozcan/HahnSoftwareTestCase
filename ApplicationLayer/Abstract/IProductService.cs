using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Abstract
{
    public interface IProductService
    {
        void UpdateProductStock(int productId, int newStockAmount);
        bool IsProductAvailable(int productId);
        decimal CalculateTotalPrice(int productId, int quantity);
        Product ProductGetByID(short id);
        IEnumerable<Product> ProductGetList();
        void ProductAdd(Product product);
        void ProductDeleteByID(short id);
        void ProductUpdate(Product product);

    }
}
