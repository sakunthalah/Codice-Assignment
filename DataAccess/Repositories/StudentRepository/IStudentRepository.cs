using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Model.Dtos;

namespace DataAccess.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        Task<StudentDto> CreateStudent(StudentDto studentObj);
        Task<StudentDto?> GetStudentById(int id);
        Task<StudentDto?> GetStudentByStudentCode(string studentCode);
        Task<StudentDto> UpdateStudent(int id, StudentDto studentObj);
        Task<bool> DeleteStudent(int id);

        Task<List<StudentsSubjectDto>> AddStudentToSubjects(List<StudentsSubjectDto> studentsSubjects);
    }
}
