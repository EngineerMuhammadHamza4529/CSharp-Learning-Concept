namespace asp.netcore1.Models
{
    public class StudentCourse
    {
        public int ID { get; set; }
        public int StudentID { get; set; } //Forigen key
        public int CourseID { get; set; } //Forigen key
        public Student student { get; set; }
        public Course course { get; set; }
    }   
}
