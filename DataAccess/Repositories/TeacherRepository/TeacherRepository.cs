using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.DbContext;
using DataAccess.Entities;
using Model.Dtos;

namespace DataAccess.Repositories.TeacherRepository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DbContext.AssignmentDbContext _dbContext;
        private readonly IMapper _mapper;

        public TeacherRepository(DbContext.AssignmentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<TeacherDto> CreateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherDto?> GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherDto?> GetTeacherByTeacherCode(string teacherCode)
        {
            throw new NotImplementedException();
        }

        public Task<TeacherDto> UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
