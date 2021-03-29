namespace CoursesDAL
{
    public class CourseInstructor
    {
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        //references
        public Course Course { get; set; }
        public Instructor Instructor { get; set; }
    }
}