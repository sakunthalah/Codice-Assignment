using AutoMapper;
using DataAccess.Entities;
using DataAccess.Repositories.StudentRepository;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;
using Model.Request;
using Model.Response;
using static Core.Exceptions.UserDefinedException;

namespace Students.API.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;

        }

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentReqest"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<StudentResponseDto>> CreateStudent(StudentRequestDto studentReqest)
        {
            if (studentReqest == null)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                StudentDto studentDto = _mapper.Map<StudentDto>(studentReqest);
                studentDto.CreatedDate = DateTime.Now;
                studentDto.CreatedBy = "admin";//need to replace with login user
                studentDto.ModifiedDate = DateTime.Now;
                studentDto.ModifiedBy = "admin";//need to replace with login user
                studentDto.Active = true;

                StudentDto? newStudent = await _studentRepository.CreateStudent(studentDto);
                if (newStudent == null)
                {
                    throw new Exception();
                }

                StudentResponseDto studentResponseDto = _mapper.Map<StudentResponseDto>(newStudent);
                return new BaseResponse<StudentResponseDto> { Success = true, Data = studentResponseDto, Message = "Inserted Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Delete Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<StudentResponseDto>?> DeleteStudent(int id)
        {
            if (id == 0)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                await _studentRepository.DeleteStudent(id);
                return new BaseResponse<StudentResponseDto> { Success = true, Data = null, Message = "Deleted Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        ///  Get Student By Student Code
        /// </summary>
        /// <param name="studentCode"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<StudentResponseDto>?> GetStudentByStudentCode(string studentCode)
        {
            if (string.IsNullOrWhiteSpace(studentCode))
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                StudentDto? studentDto = await _studentRepository.GetStudentByStudentCode(studentCode);
                if (studentDto == null)
                {
                    throw new Exception("Not Found");
                }
                StudentResponseDto studentResponseDto = _mapper.Map<StudentResponseDto>(studentDto);
                return new BaseResponse<StudentResponseDto> { Success = true, Data = studentResponseDto, Message = "Retrieved Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Get Student By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<StudentResponseDto>> GetStudentById(int id)
        {
            if (id == 0)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                StudentDto? studentDto = await _studentRepository.GetStudentById(id);
                if (studentDto == null)
                {
                    throw new Exception();
                }
                StudentResponseDto studentResponseDto = _mapper.Map<StudentResponseDto>(studentDto);
                return new BaseResponse<StudentResponseDto> { Success = true, Data = studentResponseDto, Message = "Retrieved Successfully" };
            }

            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Update Student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentReqest"></param>
        /// <returns></returns>
        /// <exception cref="UDBadRequesException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<BaseResponse<StudentResponseDto>> UpdateStudent(int id, StudentRequestDto studentReqest)
        {
            if (id == 0 || studentReqest == null)
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            try
            {
                StudentDto studentDto = _mapper.Map<StudentDto>(studentReqest);

                studentDto.ModifiedDate = DateTime.Now;
                studentDto.ModifiedBy = "admin";//need to replace with login user

                StudentDto? updatedStudent = await _studentRepository.UpdateStudent(id, studentDto);
                StudentResponseDto studentResponseDto = _mapper.Map<StudentResponseDto>(updatedStudent);
                return new BaseResponse<StudentResponseDto> { Success = true, Data = studentResponseDto, Message = "Updated Successfully" };
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public async Task<BaseResponse<StudentsSubjectResponseDto>> AddStudentToSubjects(StudentsSubjectRequestDto studentsSubjects)
        {
            if (studentsSubjects == null || !studentsSubjects.studentsSubject.Any())
            {
                throw new UDBadRequesException("Invalid Request!");
            }
            List<StudentsSubjectDto> studentsSubjectDtos = await _studentRepository.AddStudentToSubjects(studentsSubjects.studentsSubject);
            StudentsSubjectResponseDto studentSubjectResponseDto = new StudentsSubjectResponseDto();
            studentSubjectResponseDto.studentsSubject = _mapper.Map<List<StudentsSubjectDto>>(studentsSubjectDtos);
            return new BaseResponse<StudentsSubjectResponseDto> { Success = true, Data = studentSubjectResponseDto, Message = "Added Successfully" };
        }
    }
}
