using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebsiteBanHangApi.Models;

namespace WebsiteBanHangApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly WebsiteBanHangContext _context;
        public CategoryController(WebsiteBanHangContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Categories.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var cate = await _context.Categories.FindAsync(id);
            if (cate == null)
            {
                return NotFound();
            }
            return cate;
        }
        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
             _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategory), new { Id = category.Id }, category);
                
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCate(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCate(int id)
        {
            var cate = await _context.Categories.FindAsync(id);
            if (cate == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(cate);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(n => n.Id == id);
        }

    }
}
