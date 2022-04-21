using GenericCrud.Data;
using GenericCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : GenericCrudController<ToDoItem>
    {
        public ToDoItemController(DataContext context) : base(context) { }
        
        
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Search([FromQuery] ToDoSearchQuery searchQuery) 
        { 
            IQueryable<ToDoItem> query = _context.ToDoItems.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery.Name))
            {
                query = query.Where(x => x.Name == searchQuery.Name);
            }
            if (!query.Any())
            {
                return NotFound();
            }
            return await query.ToListAsync();
        
        }

    }
}
