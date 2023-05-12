using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entities;
using UnitOfWork.DAL.Repository;

namespace UnitOfWork.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Product> Products { get; }
        Task<int> SaveChangesAsync();
    }
}
