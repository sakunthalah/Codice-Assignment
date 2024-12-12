using System.Runtime.CompilerServices;
using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories.ClassRepository;
using Model.Dtos;
using Model.Request;
using Model.Response;
using static Core.Exceptions.UserDefinedException;

namespace Students.API.Managers
{
    public class ClassManager : IClassManager
    {
        private readonly IMapper _mapper;
        private readonly IClassRepository _classRepository;

        public ClassManager(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Create Class
        /// </summary>
        /// <param name="classReqest"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<ClassResponseDto>> CreateClass(ClassRequestDto classReqest)
        {
            if (classReqest == null)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                ClassDto classDto = _mapper.Map<ClassDto>(classReqest);
                classDto.CreatedDate = DateTime.Now;
                classDto.CreatedBy = "admin";//need to replace with login user
                classDto.ModifiedDate = DateTime.Now;
                classDto.ModifiedBy = "admin";//need to replace with login user
                classDto.Active = true;

                ClassDto? newClass = await _classRepository.CreateClass(classDto);
                if (newClass == null)
                {
                    throw new Exception();
                }

                ClassResponseDto classResponseDto = _mapper.Map<ClassResponseDto>(newClass);
                return new BaseResponse<ClassResponseDto> { Success = true, Data = classResponseDto, Message = "Inserted Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Delete Class
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<ClassResponseDto>?> DeleteClass(int id)
        {
            if (id == 0)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                await _classRepository.DeleteClass(id);
                return new BaseResponse<ClassResponseDto> { Success = true, Data = null, Message = "Deleted Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        ///  Get Class By Class Code
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<ClassResponseDto>?> GetClassByClassCode(string classCode)
        {
            if (string.IsNullOrWhiteSpace(classCode))
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                ClassDto? classDto = await _classRepository.GetClassByClassCode(classCode);
                if (classDto == null)
                {
                    throw new Exception("Not Found");
                }
                ClassResponseDto classResponseDto = _mapper.Map<ClassResponseDto>(classDto);
                return new BaseResponse<ClassResponseDto> { Success = true, Data = classResponseDto, Message = "Retrieved Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Get Class By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<ClassResponseDto>> GetClassById(int id)
        {
            if (id == 0)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                ClassDto? classDto = await _classRepository.GetClassById(id);
                if (classDto == null)
                {
                    throw new Exception();
                }
                ClassResponseDto classResponseDto = _mapper.Map<ClassResponseDto>(classDto);
                return new BaseResponse<ClassResponseDto> { Success = true, Data = classResponseDto, Message = "Retrieved Successfully" };
            }

            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Update Class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classReqest"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<ClassResponseDto>> UpdateClass(int id, ClassRequestDto classReqest)
        {
            if (id == 0 || classReqest == null)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                ClassDto classDto = _mapper.Map<ClassDto>(classReqest);

                classDto.ModifiedDate = DateTime.Now;
                classDto.ModifiedBy = "admin";//need to replace with login user

                ClassDto? updatedClass = await _classRepository.UpdateClass(id, classDto);
                ClassResponseDto classResponseDto = _mapper.Map<ClassResponseDto>(updatedClass);
                return new BaseResponse<ClassResponseDto> { Success = true, Data = classResponseDto, Message = "Updated Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
