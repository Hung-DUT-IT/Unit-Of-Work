using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.DbContexts;
using UnitOfWork.DAL.Entities;
using UnitOfWork.DAL.Repository;

namespace UnitOfWork.DAL.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWorks(ApplicationDbContext context)
        {
            _context = context;
        }

        private IRepository<Category> categories;
        public IRepository<Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    categories = new Repository<Category>(_context);
                }
                return categories;
            }
        }

        private IRepository<Product> products;
        public IRepository<Product> Products
        {
            get
            {
                if (products == null)
                {
                    products = new Repository<Product>(_context);
                }

                return products;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
