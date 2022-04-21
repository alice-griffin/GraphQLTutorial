using GraphQLTutorial.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTutorial.Properties.Schema.Mutations
{
    public class CourseInput
    {
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
    }
}
