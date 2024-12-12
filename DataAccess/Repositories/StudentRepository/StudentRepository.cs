using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;
using static Core.Exceptions.UserDefinedException;

namespace DataAccess.Repositories.StudentRepository
{

    public class StudentRepository : IStudentRepository
    {
        private readonly DbContext.AssignmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public StudentRepository(DbContext.AssignmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Create Student
        /// </summary>
        /// <param name="studentObj"></param>
        /// <returns></returns>
        public async Task<StudentDto> CreateStudent(StudentDto studentObj)
        {
            Student newStudent = _mapper.Map<Student>(studentObj);
            _dbContext.Add(newStudent);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<StudentDto>(newStudent);
        }

        /// <summary>
        /// Delete Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudent(int id)
        {
            var studentToDelete = await _dbContext.Students.FirstOrDefaultAsync(a => a.Id == id);

            if (studentToDelete == null)
            {
                return false;
            }

            _dbContext.Students.Remove(studentToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get Student by Student Code
        /// </summary>
        /// <param name="studentCode"></param>
        /// <returns></returns>
        public async Task<StudentDto?> GetStudentByStudentCode(string studentCode)
        {
            var studentObj = await _dbContext.Students.Where(a => a.Ssn == studentCode).FirstOrDefaultAsync();
            return _mapper.Map<StudentDto>(studentObj);
        }

        /// <summary>
        /// Get Student by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentDto?> GetStudentById(int id)
        {
            var studentObj = await _dbContext.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<StudentDto>(studentObj);

        }

        /// <summary>
        /// Update Student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentObj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<StudentDto> UpdateStudent(int id, StudentDto studentObj)
        {
            Student studentToUpdate = await _dbContext.Students.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (studentToUpdate == null)
            {
                throw new UDNotFoundException("Record Not Found!");
            }
            //studentToUpdate.Active = studentObj.Active;
            studentToUpdate.ModifiedDate = studentObj.ModifiedDate;
            studentToUpdate.ModifiedBy = studentObj.ModifiedBy;
            studentToUpdate.Ssn = studentObj.Ssn;
            studentToUpdate.FirstName = studentObj.FirstName;
            studentToUpdate.LastName = studentObj.LastName;
            studentToUpdate.PermenantAddress = studentObj.PermenantAddress;
            studentToUpdate.AdmissionDate = studentObj.AdmissionDate;
            studentToUpdate.Dob = studentObj.Dob;

            _dbContext.Update(studentToUpdate);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<StudentDto>(studentToUpdate);
        }

        public async Task<List<StudentsSubjectDto>> AddStudentToSubjects(List<StudentsSubjectDto> studentsSubjects)
        {
            try
            {


                List<StudentsSubject> studentsSubjectsData = new List<StudentsSubject>();
                foreach (var item in studentsSubjects)
                {
                    StudentsSubject studentsSubject = new StudentsSubject();
                    studentsSubject.StudentId = item.StudentId;
                    studentsSubject.SubjectId = item.SubjectId;
                    studentsSubject.Student = await _dbContext.Students.Where(a => a.Id == item.StudentId).FirstOrDefaultAsync();
                    studentsSubject.Subject = await _dbContext.Subjects.Where(a => a.Id == item.SubjectId).FirstOrDefaultAsync();
                    studentsSubject.Subject.TeacherNavigation = await _dbContext.Teachers.Where(a => a.Id == studentsSubject.Subject.Teacher).FirstOrDefaultAsync();
                    studentsSubjectsData.Add(studentsSubject);
                    //await _dbContext.StudentsSubjects.AddAsync(item);
                }

                await _dbContext.StudentsSubjects.AddRangeAsync(studentsSubjectsData);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<List<StudentsSubjectDto>>(studentsSubjectsData);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
