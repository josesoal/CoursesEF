namespace CoursesDAL
{
    public class Price
    {
        public int PriceId { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal Promotion { get; set; }
        public int CourseId { get; set; }
        
        //reference
        public Course Course { get; set; }
    }
}