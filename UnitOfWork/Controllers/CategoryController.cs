using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.BAL.Service;
using UnitOfWork.DAL.Entities;

namespace UnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<Category> _categoryService;

        private readonly IService<Category> _categoryService_1;

        public CategoryController(IService<Category> categoryService, IService<Category> categoryService_1)
        {
            _categoryService = categoryService;
            _categoryService_1 = categoryService_1;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            Console.WriteLine("First Instance:    " + _categoryService.GetID().ToString());
            Console.WriteLine("Second Instance:   " + _categoryService_1.GetID().ToString());



            return await _categoryService.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _categoryService.Add(category);


            return CreatedAtAction("GetCategory", new { id = category.IdCateogory }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.IdCateogory)
            {
                return BadRequest();
            }

            await _categoryService.Update(category);

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await _categoryService.GetById(id);

            if (category == null)
            {
                return NotFound();
            }
            else
            {
                await _categoryService.Remove(category);
            }
            return Ok();
        }
    }
}
