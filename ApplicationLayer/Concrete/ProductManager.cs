using ApplicationLayer.Abstract;
using DomainLayer.Entities;
using InfrastructureLayer.Abstract;
using InfrastructureLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _product;
        public ProductManager(IProductDal product)
        {
            _product = product;
        }
        public decimal CalculateTotalPrice(int productId, int quantity)
        {
            // Bir ürünün belirli bir miktar için toplam fiyatını hesaplamak için kullanılır.
            var product = _product.GetByID(productId);
            return product.Price * quantity;
        }

        public bool IsProductAvailable(int productId)
        {
            //Bir ürünün mevcut olup olmadığını kontrol etmek için kullanılır.

            var product = _product.GetByID(productId);
            return product.StockAmount > 0;
        }
        public void UpdateProductStock(int productId, int newStockAmount)
        {
            //Bir ürünün stok miktarını güncellemek için kullanılır.
            var product = _product.GetByID(productId);
            product.StockAmount = newStockAmount;
            _product.Update(product);
        }
        public void ProductAdd(Product product)
        {
            _product.Add(product);
        }

        public void ProductDeleteByID(short id)
        {
            _product.DeleteByID(id);
        }

        public Product ProductGetByID(short id)
        {
            return _product.GetByID(id);
        }

        public IEnumerable<Product> ProductGetList()
        {
           return _product.GetAll();
        }

        public void ProductUpdate(Product product)
        {
            _product.Update(product);
        }

     
    }
}
