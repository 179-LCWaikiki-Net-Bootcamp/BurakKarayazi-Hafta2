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
    public class NotesController : GenericCrudController<Note>
    {
        public NotesController(DataContext context) : base(context) { }

        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Note>>> Search([FromQuery] NoteSearchQuery searchQuery)
        {
            IQueryable<Note> query = _context.Notes.AsQueryable();

            if (!string.IsNullOrEmpty(searchQuery.Title))
            {
                query = query.Where(x => x.Title == searchQuery.Title);
            }

            if (!string.IsNullOrEmpty(searchQuery.Text))
            {
                query = query.Where(x => x.Text == searchQuery.Text);
            }

            if (!string.IsNullOrEmpty(searchQuery.AnyParameter))
            {
                query = query.Where(x => x.Title == searchQuery.AnyParameter || x.Text == searchQuery.AnyParameter);
            }

            if (!query.Any())
            {
                return NotFound();
            }
            return await query.ToListAsync();

        }
    }
}
