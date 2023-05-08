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

        private ICategoryRepository categories;
        public ICategoryRepository Categories
        {
            get
            {
                if (categories == null)
                {
                    categories = new CategoryRepository(_context);
                }
                return categories;
            }
        }

        private IProductRepository products;
        public IProductRepository Products
        {
            get
            {
                if (products == null)
                {
                    products = new ProductRepository(_context);
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
