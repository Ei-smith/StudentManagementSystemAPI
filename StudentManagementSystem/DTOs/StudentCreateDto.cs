using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.DTOs
{
    public class StudentCreateDto
    {
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int? Age { get; set; }

        [MaxLength(100, ErrorMessage = "Course cannot exceed 100 characters")]
        public string? Course { get; set; }
    }
}
