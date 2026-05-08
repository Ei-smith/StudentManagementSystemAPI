using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();

        Task<Student> AddStudent(StudentCreateDto dto);

        Task<Student> UpdateStudent(int id, StudentUpdateDto dto);

        Task<bool> DeleteStudent(int id);
    }
}
