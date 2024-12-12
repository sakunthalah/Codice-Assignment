using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.DbContext;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;
using static Core.Exceptions.UserDefinedException;

namespace DataAccess.Repositories.SubjectRepository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DbContext.AssignmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public SubjectRepository(DbContext.AssignmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Create Subject
        /// </summary>
        /// <param name="subjectObj"></param>
        /// <returns></returns>
        public async Task<SubjectDto> CreateSubject(SubjectDto subjectObj)
        {
            Subject newSubject = _mapper.Map<Subject>(subjectObj);
            _dbContext.Add(newSubject);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubjectDto>(newSubject);
        }

        /// <summary>
        /// Delete Subject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteSubject(int id)
        {
            var subjectToDelete = await _dbContext.Subjects.FirstOrDefaultAsync(a => a.Id == id);

            if (subjectToDelete == null)
            {
                return false;
            }

            _dbContext.Subjects.Remove(subjectToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }


        /// <summary>
        /// Get Subject by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SubjectDto?> GetSubjectById(int id)
        {
            var subjectObj = await _dbContext.Subjects.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<SubjectDto>(subjectObj);

        }

        /// <summary>
        /// Update Subject
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectObj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<SubjectDto> UpdateSubject(int id, SubjectDto subjectObj)
        {
            Subject subjectToUpdate = await _dbContext.Subjects.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (subjectToUpdate == null)
            {
                throw new UDNotFoundException("Record Not Found!");
            }
            //subjectToUpdate.Active = subjectObj.Active;
            subjectToUpdate.ModifiedDate = subjectObj.ModifiedDate;
            subjectToUpdate.ModifiedBy = subjectObj.ModifiedBy;
            subjectToUpdate.SubjectName = subjectObj.SubjectName;
            subjectToUpdate.Teacher = subjectObj.Teacher;
            subjectToUpdate.Code = subjectObj.Code;

            _dbContext.Update(subjectToUpdate);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubjectDto>(subjectToUpdate);
        }
    }
}
