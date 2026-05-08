using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentController> _logger;

        public StudentController(
            IStudentService service,
            ILogger<StudentController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            _logger.LogInformation("Fetching all students");

            var students = await _service.GetAllStudents();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentCreateDto dto)
        {
            var student = await _service.AddStudent(dto);

            return Ok(new
            {
                Message = "Student Added successfully",
                Data = student
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, StudentUpdateDto dto)
        {
            var student = await _service.UpdateStudent(id, dto);

            if (student == null)
                return NotFound();

            return Ok(new
            {
                Message = "Student updated successfully",
                Data = student
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _service.DeleteStudent(id);

            if (!result)
                return NotFound();

            return Ok("Student Deleted Successfully");
        }
       
    }
}
