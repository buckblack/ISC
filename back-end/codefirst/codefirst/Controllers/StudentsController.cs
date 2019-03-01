using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codefirst.Models;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;

namespace codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly Db _context;
        private readonly HostingEnvironment _hostingEnvironment;
        public StudentsController(HostingEnvironment hostingEnvironment, Db context)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentID)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent([FromForm] Student student)
        {
            var file = student.File;
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            if (file!=null)
            {
                string newFilename = student.StudentID + "_" + file.FileName;
                string path = _hostingEnvironment.ContentRootPath + "\\data\\" + file.FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    student.ImagePath = newFilename;
                    _context.Entry(student).Property(x => x.ImagePath).IsModified = true;
                    _context.SaveChanges();
                }
                    
            }
            
            return CreatedAtAction("GetStudent", new { id = student.StudentID }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentID == id);
        }
    }
}
