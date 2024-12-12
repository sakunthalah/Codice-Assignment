using DataAccess.Entities;
using Model.Request;
using Model.Response;

namespace Students.API.Managers
{
    public interface IClassManager
    {
        Task<BaseResponse<ClassResponseDto>> GetClassById(int id);
        Task<BaseResponse<ClassResponseDto>> CreateClass(ClassRequestDto newClass);
        Task<BaseResponse<ClassResponseDto>?> GetClassByClassCode(string classCode);
        Task<BaseResponse<ClassResponseDto>> UpdateClass(int id, ClassRequestDto classObj);
        Task<BaseResponse<ClassResponseDto>> DeleteClass(int id);
    }
}
