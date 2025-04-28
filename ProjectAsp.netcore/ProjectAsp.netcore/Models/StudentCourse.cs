namespace ProjectAsp.netcore.Models
{
    public class StudentCourse
    {
        public int ID { get; set; }
        public int StudentID { get; set; } //Foreign key
        public int CourseID { get; set; } //Foreign key
        public Student student { get; set; }
        public Course course { get; set; }
    }
}