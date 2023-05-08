using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entities;
using UnitOfWork.DAL.UnitOfWork;

namespace UnitOfWork.BAL.Service
{
    public class ProductService : IService<Product>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.Products.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.Products.GetById(id);
        }

        public async Task Add(Product entity)
        {
            await _unitOfWork.Products.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(Product entity)
        {
            await _unitOfWork.Products.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Remove(Product entity)
        {
            await _unitOfWork.Products.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
