using AutoMapper;
using DataAccess.Repositories.SubjectRepository;
using Model.Dtos;
using Model.Request;
using Model.Response;
using static Core.Exceptions.UserDefinedException;

namespace Subjects.API.Managers
{
    public class SubjectManager : ISubjectManager
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;

        public SubjectManager(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Create Subject
        /// </summary>
        /// <param name="subjectReqest"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<SubjectResponseDto>> CreateSubject(SubjectRequestDto subjectReqest)
        {
            if (subjectReqest == null)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                SubjectDto subjectDto = _mapper.Map<SubjectDto>(subjectReqest);
                subjectDto.CreatedDate = DateTime.Now;
                subjectDto.CreatedBy = "admin";//need to replace with login user
                subjectDto.ModifiedDate = DateTime.Now;
                subjectDto.ModifiedBy = "admin";//need to replace with login user
                subjectDto.Active = true;

                SubjectDto? newSubject = await _subjectRepository.CreateSubject(subjectDto);
                if (newSubject == null)
                {
                    throw new Exception();
                }

                SubjectResponseDto subjectResponseDto = _mapper.Map<SubjectResponseDto>(newSubject);
                return new BaseResponse<SubjectResponseDto> { Success = true, Data = subjectResponseDto, Message = "Inserted Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Delete Subject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<SubjectResponseDto>?> DeleteSubject(int id)
        {
            if (id == 0)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                await _subjectRepository.DeleteSubject(id);
                return new BaseResponse<SubjectResponseDto> { Success = true, Data = null, Message = "Deleted Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Get Subject By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<SubjectResponseDto>> GetSubjectById(int id)
        {
            if (id == 0)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                SubjectDto? subjectDto = await _subjectRepository.GetSubjectById(id);
                if (subjectDto == null)
                {
                    throw new Exception();
                }
                SubjectResponseDto subjectResponseDto = _mapper.Map<SubjectResponseDto>(subjectDto);
                return new BaseResponse<SubjectResponseDto> { Success = true, Data = subjectResponseDto, Message = "Retrieved Successfully" };
            }

            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Update Subject
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectReqest"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<SubjectResponseDto>> UpdateSubject(int id, SubjectRequestDto subjectReqest)
        {
            if (id == 0 || subjectReqest == null)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                SubjectDto subjectDto = _mapper.Map<SubjectDto>(subjectReqest);

                subjectDto.ModifiedDate = DateTime.Now;
                subjectDto.ModifiedBy = "admin";//need to replace with login user

                SubjectDto? updatedSubject = await _subjectRepository.UpdateSubject(id, subjectDto);
                SubjectResponseDto subjectResponseDto = _mapper.Map<SubjectResponseDto>(updatedSubject);
                return new BaseResponse<SubjectResponseDto> { Success = true, Data = subjectResponseDto, Message = "Updated Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
