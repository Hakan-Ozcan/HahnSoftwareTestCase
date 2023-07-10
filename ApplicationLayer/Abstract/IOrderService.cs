using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Abstract
{
    public interface IOrderService
    {
        Orders OrderGetByID(short id);
        IEnumerable<Orders> OrderGetList();
        void OrderAdd(Orders order);
        void OrderDeleteByID(short id);
        void OrderUpdate(Orders order);
        decimal CalculateTotalOrderAmount(int id);
        bool IsOrderComplete(int id);
    }
}
