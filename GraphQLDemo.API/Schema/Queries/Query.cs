using Bogus;
using GraphQLDemo.API.Dtos;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services.Courses;
using System.Reflection.Metadata.Ecma335;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        private readonly CoursesRepository _coursesRepository;
        public Query(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        public async Task<IEnumerable<CourseType>> GetCourses()
        {
            IEnumerable<CourseDto> courseDtos = await _coursesRepository.GetAll();
            return courseDtos.Select(c => new CourseType()
            {
                Id = c.Id,
                Name = c.Name,
                Subject = c.Subject,
                Instructor = new InstructorType()
                {
                    Id = c.Instructor.Id,
                    FirstName = c.Instructor.FirstName,
                    LastName = c.Instructor.LastName,
                    Salary = c.Instructor.Salary
                }
            });
        }
        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            CourseDto courseDTO = await _coursesRepository.GetById(id);
            return  new CourseType()
            {
                Id = courseDTO.Id,
                Name = courseDTO.Name,
                Subject = courseDTO.Subject,
                Instructor = new InstructorType()
                {
                    Id = courseDTO.Instructor.Id,
                    FirstName = courseDTO.Instructor.FirstName,
                    LastName = courseDTO.Instructor.LastName,
                    Salary = courseDTO.Instructor.Salary
                }
            };
        }
    }
}
