using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Model.Dtos;

namespace DataAccess.Repositories.TeacherRepository
{
    public interface ITeacherRepository
    {
        Task<TeacherDto> CreateTeacher(Teacher teacher);
        Task<TeacherDto?> GetTeacherById(int id);
        Task<TeacherDto?> GetTeacherByTeacherCode(string teacherCode);
        Task<TeacherDto> UpdateTeacher(Teacher teacher);
        Task<bool> DeleteTeacher(Teacher teacher);
    }
}
