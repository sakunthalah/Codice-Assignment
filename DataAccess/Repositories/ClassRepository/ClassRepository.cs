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
using Model.Response;
using static Core.Exceptions.UserDefinedException;

namespace DataAccess.Repositories.ClassRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly AssignmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClassRepository(AssignmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Create Class
        /// </summary>
        /// <param name="classObj"></param>
        /// <returns></returns>
        public async Task<ClassDto> CreateClass(ClassDto classObj)
        {
            Class newClass = _mapper.Map<Class>(classObj);
            _dbContext.Add(newClass);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ClassDto>(newClass);
        }

        /// <summary>
        /// Delete Class
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteClass(int id)
        {
            var classToDelete = await _dbContext.Classes.FirstOrDefaultAsync(a => a.Id == id);

            if (classToDelete == null)
            {
                return false;
            }

            _dbContext.Classes.Remove(classToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Get Class by Class Code
        /// </summary>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public async Task<ClassDto?> GetClassByClassCode(string classCode)
        {
            var classObj = await _dbContext.Classes.Where(a => a.ClassCode == classCode).FirstOrDefaultAsync();
            return _mapper.Map<ClassDto>(classObj);
        }

        /// <summary>
        /// Get Class by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ClassDto?> GetClassById(int id)
        {
            var classObj = await _dbContext.Classes.Where(a => a.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ClassDto>(classObj);

        }

        /// <summary>
        /// Update Class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="classObj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ClassDto> UpdateClass(int id, ClassDto classObj)
        {
            Class classToUpdate = await _dbContext.Classes.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (classToUpdate == null)
            {
                throw new UDNotFoundException("Record Not Found!");
            }
            //classToUpdate.Active = classObj.Active;
            classToUpdate.ModifiedDate = classObj.ModifiedDate;
            classToUpdate.ModifiedBy = classObj.ModifiedBy;
            classToUpdate.ClassCode = classObj.ClassCode;
            classToUpdate.ClassName = classObj.ClassName;

            _dbContext.Update(classToUpdate);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ClassDto>(classToUpdate);
        }

    }
}
