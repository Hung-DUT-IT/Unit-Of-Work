using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.DbContexts;
using UnitOfWork.DAL.Entities;

namespace UnitOfWork.DAL.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> CategoryExists(int idCategory)
        {
            return await _dbContext.Categories.AnyAsync(c => c.IdCateogory == idCategory);
        }
    }
}
