using Microsoft.AspNetCore.Mvc;
using Model.Dtos;
using Model.Request;
using Model.Response;
using Students.API.Managers;

namespace Students.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        IStudentManager _studentManager;
        public StudentController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            BaseResponse<StudentResponseDto> response = await _studentManager.GetStudentById(id);
            return Ok(response);
        }

        [HttpGet("by-code/{code}")]
        public async Task<IActionResult> GetStudentByCode(string code)
        {
            BaseResponse<StudentResponseDto> response = await _studentManager.GetStudentByStudentCode(code);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequestDto studentReqestDto)
        {
            BaseResponse<StudentResponseDto> createdStudent = await _studentManager.CreateStudent(studentReqestDto);
            return Ok(createdStudent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentRequestDto studentReqestDto)
        {
            BaseResponse<StudentResponseDto> createdStudent = await _studentManager.UpdateStudent(id, studentReqestDto);
            return Ok(createdStudent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            BaseResponse<StudentResponseDto> createdStudent = await _studentManager.DeleteStudent(id);
            return Ok(createdStudent);
        }

        [HttpPost("Add-Student-to-Subjects/")]
        public async Task<IActionResult> AddStudentToSubjects([FromBody] StudentsSubjectRequestDto studentsSubjectRequestDto)
        {
            BaseResponse<StudentsSubjectResponseDto> response = await _studentManager.AddStudentToSubjects(studentsSubjectRequestDto);
            return Ok(response);
        }
    }
}
