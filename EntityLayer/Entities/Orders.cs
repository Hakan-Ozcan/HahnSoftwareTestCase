using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }//information on which product we are selling
        public string EmployeeId { get; set; } // employee to deliver the order
        public int Amount { get; set; }
        public int Price { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderCompleteDate { get; set; }

    }
}
