using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            // We will add GetTodoItem later, so for now just return Ok or CreatedAtAction with null
            // To follow strict compilation, we can return Ok(todoItem) or CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem) if Get exists.
            // Since Get doesn't exist yet in this feature, I'll return Ok(todoItem).
            return Ok(todoItem);
        }
    }
}
