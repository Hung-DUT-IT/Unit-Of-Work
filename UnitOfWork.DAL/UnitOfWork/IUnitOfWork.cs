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
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
        Task<int> SaveChangesAsync();
    }
}
