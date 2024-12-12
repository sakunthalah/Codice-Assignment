using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using Model.Dtos;

namespace DataAccess.Repositories.SubjectRepository
{
    public interface ISubjectRepository
    {
        Task<SubjectDto> CreateSubject(SubjectDto subjectObj);
        Task<SubjectDto?> GetSubjectById(int id);
        Task<SubjectDto> UpdateSubject(int id, SubjectDto subjectObj);
        Task<bool> DeleteSubject(int id);

    }
}
