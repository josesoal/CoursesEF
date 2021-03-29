using System;
using System.Collections.Generic;
namespace CoursesDAL
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        
        //reference
        public Price PriceCourse { get; set; }
        public ICollection<Comment> CommentList { get; set; }
        public ICollection<CourseInstructor> CourseInstructorList { get; set; } 
    }
}