using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entities;

namespace UnitOfWork.DAL.Repository
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<bool> ProductExists(int idProduct);
    }
}
