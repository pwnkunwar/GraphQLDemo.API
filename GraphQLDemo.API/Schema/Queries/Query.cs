using Bogus;
using System.Reflection.Metadata.Ecma335;

namespace GraphQLDemo.API.Schema.Queries
{
    public class Query
    {
        [GraphQLName("getCourses")]
        public IEnumerable<CourseType> GetCourses()
        {
            Faker<InstructorType> instructorFaker = new Faker<InstructorType>()
                .RuleFor(c => c.Id, f => Guid.NewGuid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Salary, f => f.Random.Double(0, 100000));

            Faker<StudentType> studentFaker = new Faker<StudentType>()
               .RuleFor(c => c.Id, f => Guid.NewGuid())
               .RuleFor(c => c.FirstName, f => f.Name.FirstName())
               .RuleFor(c => c.LastName, f => f.Name.LastName())
               .RuleFor(c => c.GPA, f => f.Random.Double(1, 4));

            Faker<CourseType> courseFaker = new Faker<CourseType>()
   .RuleFor(c => c.Id, f => Guid.NewGuid())
   .RuleFor(c => c.Name, f => f.Name.JobTitle())
   .RuleFor(c => c.Subject, f => f.PickRandom<Subject>())
   .RuleFor(c => c.Instructor, f => instructorFaker.Generate())
   .RuleFor(c => c.Students, f => studentFaker.Generate(3));



            return courseFaker.Generate(5);


        }
        [GraphQLDeprecated("This query is depricated.")]
        public string Instructions => "UnderTaker";
    }
}
