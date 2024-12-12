using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Model.Dtos;

namespace DataAccess.Repositories.ClassRepository
{
    public interface IClassRepository
    {
        Task<ClassDto> CreateClass(ClassDto classObj);
        Task<ClassDto?> GetClassById(int id);
        Task<ClassDto?> GetClassByClassCode(string classCode);
        Task<ClassDto> UpdateClass(int id, ClassDto classObj);
        Task<bool> DeleteClass(int id);
    }
}
