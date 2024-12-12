using Model.Request;
using Model.Response;

namespace Subjects.API.Managers
{
    public interface ISubjectManager
    {
        Task<BaseResponse<SubjectResponseDto>> GetSubjectById(int id);
        Task<BaseResponse<SubjectResponseDto>> CreateSubject(SubjectRequestDto newSubject);
        Task<BaseResponse<SubjectResponseDto>> UpdateSubject(int id, SubjectRequestDto classObj);
        Task<BaseResponse<SubjectResponseDto>> DeleteSubject(int id);
    }
}
