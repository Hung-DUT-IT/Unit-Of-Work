using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.DbContexts;
using UnitOfWork.DAL.Entities;

namespace UnitOfWork.DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> ProductExists(int idProduct)
        {
            return await _dbContext.Products.AnyAsync(c => c.IdProduct == idProduct);
        }
    }
}
