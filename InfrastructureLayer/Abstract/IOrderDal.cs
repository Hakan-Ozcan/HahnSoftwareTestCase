using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Abstract
{
    public interface IOrderDal:IRepositoryDal<Orders>
    {
    }
}
