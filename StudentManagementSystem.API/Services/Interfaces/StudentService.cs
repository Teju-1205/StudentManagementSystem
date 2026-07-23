using StudentManagementSystem.API.Services.Interfaces;
using StudentManagementSystem.DTOs;
using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(
            IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StudentResponseDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();

            return students.Select(s => new StudentResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Course = s.Course,
                CreatedDate = s.CreatedDate
            }).ToList();
        }

        public async Task<StudentResponseDto?> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                return null;

            return new StudentResponseDto
            {
                Id = student.Id,
                Name = student.Name,
                Email = student.Email,
                Age = student.Age,
                Course = student.Course,
                CreatedDate = student.CreatedDate
            };
        }

        public async Task<StudentResponseDto> CreateAsync(
            StudentCreateDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                Email = dto.Email,
                Age = dto.Age,
                Course = dto.Course,
                CreatedDate = DateTime.UtcNow
            };

            var created = await _repository.AddAsync(student);

            return new StudentResponseDto
            {
                Id = created.Id,
                Name = created.Name,
                Email = created.Email,
                Age = created.Age,
                Course = created.Course,
                CreatedDate = created.CreatedDate
            };
        }

        public async Task<bool> UpdateAsync(
            int id,
            StudentUpdateDto dto)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                return false;

            student.Name = dto.Name;
            student.Email = dto.Email;
            student.Age = dto.Age;
            student.Course = dto.Course;

            await _repository.UpdateAsync(student);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
                return false;

            await _repository.DeleteAsync(student);

            return true;
        }
    }
}