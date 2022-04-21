using GraphQLTutorial.Properties.Enums;
using GraphQLTutorial.Properties.Schema.Subscriptions;
using HotChocolate;
using HotChocolate.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTutorial.Properties.Schema.Mutations
{
    public class Mutation
    {

        private readonly List<CourseResult> courses;

        public Mutation()
        {
            courses = new List<CourseResult>();
        }
        public async Task<CourseResult> CreateCourse(CourseInput course, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult courseType = new CourseResult()
            {
                Id = Guid.NewGuid(),
                Name = course.Name,
                Subject = course.Subject,
                InstructorId = course.InstructorId
            };
            courses.Add(courseType);
            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), courseType);
            return courseType;
        }

        public CourseResult UpdateCourse(CourseInput course, Guid id, [Service] ITopicEventSender topicEventSender)
        {
            CourseResult courseToUpdate = courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                throw new GraphQLException(new Error("Course not found.", "COURSE_NOT_FOUND"));
            }

            courseToUpdate.Name = course.Name;
            courseToUpdate.Subject = course.Subject;
            courseToUpdate.InstructorId = course.InstructorId;

            string updateCourseTopic = $"{course.Name}_{nameof(Subscription.CourseUpdated)}";

            return courseToUpdate;

        }

        public bool DeleteCourse(Guid id)
        {
            return courses.RemoveAll(c => c.Id == id) >= 1;
        }
    }
}
