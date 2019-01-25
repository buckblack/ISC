using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todoapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            return await _context.todoItems.ToListAsync();
        }

        // GET: api/Todo/CompletedTask
        [HttpGet("CompletedTask")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTask()
        {
            return await _context.todoItems.Where(x => x.IsComplete == true).ToArrayAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>>Get(long id)
        {
            var todoItem = await _context.todoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post(TodoItem todoItem)
        {
            _context.todoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            //return todoItem;
            return CreatedAtAction("Get", new { id = todoItem.Id }, todoItem);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> Put(long id,TodoItem todoItem)
        {
            var todo = await _context.todoItems.FindAsync(id);
            if (todo == null)
                return NotFound();
            todo.Name = todoItem.Name;
            todo.IsComplete = todoItem.IsComplete;
            _context.todoItems.Update(todo);
            await _context.SaveChangesAsync();
            return Ok(todo);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> Delete(long id)
        {
            var todo = await _context.todoItems.FindAsync(id);
            if (todo == null)
                return NotFound();
            _context.todoItems.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        //get: api/Todo/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Search([FromQuery] string q)
        {
            return await _context.todoItems.Where(x => x.Name.Contains(q)).ToArrayAsync();
        }
    }
}
