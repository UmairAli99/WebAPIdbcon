using Microsoft.AspNetCore.Mvc;
using SharedClassLibrary;
using WebAPIdbcon.Model;

namespace WebAPIdbcon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.student.Add(student);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = student.id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = _context.student.FirstOrDefault(s => s.id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.name = student.name;
            existingStudent.cnic = student.cnic;
            existingStudent.semester = student.semester;
            existingStudent.cgpa = student.cgpa;

            _context.SaveChanges();

            return Ok(existingStudent);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _context.student.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}