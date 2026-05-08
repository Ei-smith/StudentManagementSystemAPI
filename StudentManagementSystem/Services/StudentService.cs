using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return await _repository.GetAllStudents();
        }

        public async Task<Student> AddStudent(StudentCreateDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = (int)dto.Age,
                Course = dto.Course
            };

            return await _repository.AddStudent(student);
        }

        public async Task<Student> UpdateStudent(int id, StudentUpdateDto dto)
        {
            var existingStudent = await _repository.GetStudentById(id);

            if (existingStudent == null)
                return null;

            existingStudent.Name = dto.Name ?? existingStudent.Name;

            existingStudent.Email = dto.Email ?? existingStudent.Email;

            existingStudent.Course = dto.Course ?? existingStudent.Course;

            existingStudent.Age = dto.Age ?? existingStudent.Age;

            return await _repository.UpdateStudent(existingStudent);
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _repository.DeleteStudent(id);
        }
    }
}
