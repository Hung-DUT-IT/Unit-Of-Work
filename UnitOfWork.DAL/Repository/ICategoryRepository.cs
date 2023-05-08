using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entities;

namespace UnitOfWork.DAL.Repository
{
    public interface ICategoryRepository: IRepository<Category>
    {
        Task<bool> CategoryExists(int idCategory);
    }
}
