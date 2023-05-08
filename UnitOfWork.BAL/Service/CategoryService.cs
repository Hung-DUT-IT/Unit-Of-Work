using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.DAL.Entities;
using UnitOfWork.DAL.UnitOfWork;

namespace UnitOfWork.BAL.Service
{
    public class CategoryService : IService<Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(Category entity)
        {
            await _unitOfWork.Categories.Add(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _unitOfWork.Categories.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            return await _unitOfWork.Categories.GetById(id);
        }

        public async Task Remove(Category entity)
        {
            await _unitOfWork.Categories.Delete(entity);
            await _unitOfWork.SaveChangesAsync(); 
        }

        public async Task Update(Category entity)
        {
            await _unitOfWork.Categories.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
