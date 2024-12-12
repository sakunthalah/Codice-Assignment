using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using Students.API.Managers;

namespace Students.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        IClassManager _classManager;
        public ClassController(IClassManager classManager) 
        { 
            _classManager = classManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClassById(int id)
        {
            BaseResponse<ClassResponseDto> response = await _classManager.GetClassById(id);
            return Ok(response);
        }

        [HttpGet("by-code/{code}")]
        public async Task<IActionResult> GetClassByCode(string code)
        {
            BaseResponse<ClassResponseDto> response = await _classManager.GetClassByClassCode(code);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass([FromBody] ClassRequestDto classReqestDto)
        {
            BaseResponse<ClassResponseDto> createdClass = await _classManager.CreateClass(classReqestDto);
            return Ok(createdClass);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, [FromBody] ClassRequestDto classReqestDto)
        {
            BaseResponse<ClassResponseDto> createdClass = await _classManager.UpdateClass(id, classReqestDto);
            return Ok(createdClass);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            BaseResponse<ClassResponseDto> createdClass = await _classManager.DeleteClass(id);
            return Ok(createdClass);
        }
    }
}
