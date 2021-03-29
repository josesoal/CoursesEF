using System.Collections.Generic;

namespace CoursesDAL
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Category { get; set; }
        public byte[] Photo { get; set; }

        //reference
        public ICollection<CourseInstructor> CourseInstructorList { get; set; }
    }
}