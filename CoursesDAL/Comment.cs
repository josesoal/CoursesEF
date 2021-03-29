namespace CoursesDAL
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Student { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }
        public int CourseId { get; set; }

        //reference
        public Course Course { get; set; }
    }
}