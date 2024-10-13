﻿namespace GraphQLDemo.API.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [GraphQLName("gpa")]
        public double GPA { get; set; }
        public IEnumerable<StudentDto> Courses { get; set; }
    }
}
