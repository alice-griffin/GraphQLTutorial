using GraphQLTutorial.Properties.Enums;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTutorial.Properties.Schema
{
    public class CourseType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StudentType> Students { get; set; }

        [GraphQLNonNullType]
        public InstructorType Instructor { get; set; }

        public Subject Subject { get; set; }
    }
}
