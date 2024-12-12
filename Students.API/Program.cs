using AutoMapper;
using DataAccess.DbContext;
using DataAccess.Entities;
using DataAccess.Repositories.ClassRepository;
using DataAccess.Repositories.StudentRepository;
using DataAccess.Repositories.SubjectRepository;
using DataAccess.Repositories.TeacherRepository;
using Students.API.CustomConfiguration;
using Students.API.Managers;
using Students.API.Middlewares;
using Subjects.API.Managers;

var builder = WebApplication.CreateBuilder(args);

// Automapper config
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/*
 * Dependency Injection
 */
builder.Services.AddSingleton<AssignmentDbContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IClassManager, ClassManager>();
builder.Services.AddScoped<IStudentManager, StudentManager>();
builder.Services.AddScoped<ISubjectManager, SubjectManager>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.Run();
