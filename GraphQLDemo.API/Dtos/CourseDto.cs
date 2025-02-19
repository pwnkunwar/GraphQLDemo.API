﻿using GraphQLDemo.API.Models;
using GraphQLDemo.API.Schema;

namespace GraphQLDemo.API.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
        public InstructorDto Instructor { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
