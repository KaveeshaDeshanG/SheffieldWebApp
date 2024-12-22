namespace SheffieldWebApp.Models
{
    public class AdminModel
    {
        public IEnumerable<Student> students { get; set; }
        public IEnumerable<Subject> subjects { get; set; }
        public List<Grade> grades { get; set; }
        public IEnumerable<Teacher> teachers { get; set; }
    }
}
