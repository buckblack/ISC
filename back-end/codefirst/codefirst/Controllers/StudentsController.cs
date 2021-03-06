﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using codefirst.Models;
using Microsoft.AspNetCore.Hosting.Internal;
using System.IO;
using codefirst.Models.respone;
using codefirst.Models.request;

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
        /*public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }*/
        public async Task<ActionResult<PagingRespone>> GetStudents([FromQuery] PagingResquest req)
        {
            var query = _context.Students.Include(x => x.Major).AsNoTracking().Select(x => new Student {
                StudentID = x.StudentID,
                Code = x.Code,
                Name = x.Name,
                Major = x.Major
            });//.orderby() nếu cần
            long totalRows = query.LongCount();
            var pageCount = (double)totalRows / req.Size;
            int totalPage = (int)Math.Ceiling(pageCount);
            var skip = (req.Page - 1) * req.Size;
            var results = await query.Skip(skip).Take(req.Size).ToListAsync();
            return new PagingRespone
            {
                Data = results,
                PaginInfo = new PagingInfo
                {
                    CurrentPage = req.Page,
                    PageSize = req.Size,
                    TotalRecords = totalRows,
                    TotalPages = totalPage
                }
            };
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
        public async Task<IActionResult> PutStudent(int id,[FromForm] Student student)
        {
            var file = student.File;
            var st = await _context.Students.FindAsync(id);
            if (st == null)
            {
                return BadRequest();
            }
            var oldFile = st.ImagePath;
            st.Name = student.Name;
            st.MajorID = student.MajorID;
            if(file!=null)
            {
                //xóa file
                oldFile = _hostingEnvironment.WebRootPath + "\\data\\" + oldFile;
                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }

                string newFile = st.StudentID + "_" + file.FileName;
                string path = _hostingEnvironment.WebRootPath + "\\data\\" + newFile;
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        
                        file.CopyTo(stream);                    
                        st.ImagePath = newFile;                       
                    }
            }
            _context.SaveChanges();
            return Ok(st);
            
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
                string path = _hostingEnvironment.WebRootPath + "\\data\\" + file.FileName;
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
