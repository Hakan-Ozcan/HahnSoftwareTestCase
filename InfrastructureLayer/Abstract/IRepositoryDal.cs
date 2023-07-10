using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Abstract
{
    public interface IRepositoryDal<T>where T : class
    {
        IEnumerable<T> GetAll(); //multiple read
        T GetByID(int id); //single read
        void Add(T entity); //create
        void Update(T entity); //update
        void DeleteByID(int id); //delete
    }
}
