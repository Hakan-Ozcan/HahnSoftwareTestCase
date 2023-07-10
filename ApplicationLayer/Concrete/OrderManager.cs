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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderdal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderdal = orderDal;
        }
        public decimal CalculateTotalOrderAmount(int id)
        {
            var order = _orderdal.GetByID(id);

            // Örnek hesaplama işlemleri
            decimal totalAmount = order.Amount * order.Price;

            return totalAmount;
        }

        public bool IsOrderComplete(int id)
        {
            var order = _orderdal.GetByID(id);

            // Örnek kontrol işlemleri
            bool isComplete = order.OrderCompleteDate.HasValue;

            return isComplete;
        }

        public void OrderAdd(Orders order)
        {
            _orderdal.Add(order);
        }

        public void OrderDeleteByID(short id)
        {
            _orderdal.DeleteByID(id);
        }

        public Orders OrderGetByID(short id)
        {
            return _orderdal.GetByID(id);
        }

        public IEnumerable<Orders> OrderGetList()
        {
            return _orderdal.GetAll();
        }

        public void OrderUpdate(Orders order)
        {
            _orderdal.Update(order);
        }
    }
}
