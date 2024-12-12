using Model.Dtos;
using Model.Request;
using Model.Response;

namespace Students.API.Managers
{
    public interface IStudentManager
    {
        Task<BaseResponse<StudentResponseDto>> GetStudentById(int id);
        Task<BaseResponse<StudentResponseDto>> CreateStudent(StudentRequestDto newStudent);
        Task<BaseResponse<StudentResponseDto>?> GetStudentByStudentCode(string classCode);
        Task<BaseResponse<StudentResponseDto>> UpdateStudent(int id, StudentRequestDto classObj);
        Task<BaseResponse<StudentResponseDto>> DeleteStudent(int id);
        Task<BaseResponse<StudentsSubjectResponseDto>> AddStudentToSubjects(StudentsSubjectRequestDto studentsSubjects);
    }
}
