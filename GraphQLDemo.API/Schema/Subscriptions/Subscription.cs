using GraphQLDemo.API.Schema.Mutations;

namespace GraphQLDemo.API.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

    }
}
