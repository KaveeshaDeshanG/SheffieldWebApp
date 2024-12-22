namespace SheffieldWebApp.Models

{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<AssignedStudent>? Students { get; set; }
    }

    public class AssignedStudent
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string StudentId { get; set; }
    }

    public class SubjectDetailsViewModel
    {
        public Subject Subject { get; set; }
        public List<Grade> Grades { get; set; }
    }

}
