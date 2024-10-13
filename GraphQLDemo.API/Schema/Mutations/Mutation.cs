using GraphQLDemo.API.Dtos;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services.Courses;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly CoursesRepository _coursesRepository;
        public Mutation(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        public async Task<CourseResult> CreateCourse(CourseType courseInput, [Service] ITopicEventSender topicEventSender)
        {
            CourseDto courseDto = new CourseDto()
            {
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };

            courseDto = await _coursesRepository.Create(courseDto);
            CourseResult course = new CourseResult()
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Subject = courseDto.Subject,
                InstructorId = courseDto.InstructorId
            };

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);
            return course;
        }

        public async Task<CourseResult> UpdateCourse(Guid id , CourseType courseInput)
        {
            CourseDto courseDto = new CourseDto()
            {
                Id = id,
                Name = courseInput.Name,
                Subject = courseInput.Subject,
                InstructorId = courseInput.InstructorId
            };
            courseDto = await _coursesRepository.Update(courseDto);
            CourseResult course = new CourseResult()
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Subject = courseDto.Subject,
                InstructorId = courseDto.InstructorId
            };
            return course;
        }
        public async Task<bool> DeleteCourse(Guid id)
        {
            return await _coursesRepository.Delete(id);
        }
    }
}
