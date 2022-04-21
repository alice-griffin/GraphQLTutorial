using GraphQLTutorial.Properties.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLTutorial.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StudentDTO> Students { get; set; }

        public InstructorDTO Instructor { get; set; }

        public Subject Subject { get; set; }
    }
}
