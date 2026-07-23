using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.API.Services.Interfaces;
using StudentManagementSystem.DTOs;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(
            IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _service.GetAllAsync();

            return Ok(new
            {
                success = true,
                data = students
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _service.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Student not found."
                });
            }

            return Ok(new
            {
                success = true,
                data = student
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            StudentCreateDto dto)
        {
            var student = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.Id },
                new
                {
                    success = true,
                    message = "Student created successfully.",
                    data = student
                });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            StudentUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (!result)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Student not found."
                });
            }

            return Ok(new
            {
                success = true,
                message = "Student updated successfully."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Student not found."
                });
            }

            return Ok(new
            {
                success = true,
                message = "Student deleted successfully."
            });
        }
    }
}