namespace SheffieldWebApp.Models
{
    public class TeacherDashboard
    {
        public List<Student> students { get; set; }
        public List<AssignedStudent> assignedStudents { get; set; }
        public List<Mark> marks { get; set; }

        public IEnumerable<Subject> subjects { get; set; }
        public IEnumerable<Grade> grades { get; set; }
        public IEnumerable<Teacher> teachers { get; set; }
    }
}
