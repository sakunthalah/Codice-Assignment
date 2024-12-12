using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using Subjects.API.Managers;

namespace Subjects.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase
    {
        ISubjectManager _subjectManager;
        public SubjectController(ISubjectManager subjectManager)
        {
            _subjectManager = subjectManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubjectById(int id)
        {
            BaseResponse<SubjectResponseDto> response = await _subjectManager.GetSubjectById(id);
            return Ok(response);
        }

      
        [HttpPost]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectRequestDto subjectReqestDto)
        {
            BaseResponse<SubjectResponseDto> createdSubject = await _subjectManager.CreateSubject(subjectReqestDto);
            return Ok(createdSubject);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(int id, [FromBody] SubjectRequestDto subjectReqestDto)
        {
            BaseResponse<SubjectResponseDto> createdSubject = await _subjectManager.UpdateSubject(id, subjectReqestDto);
            return Ok(createdSubject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            BaseResponse<SubjectResponseDto> createdSubject = await _subjectManager.DeleteSubject(id);
            return Ok(createdSubject);
        }
    }
}
