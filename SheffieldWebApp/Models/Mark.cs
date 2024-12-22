using System.ComponentModel.DataAnnotations;

namespace SheffieldWebApp.Models

{
    public class Mark
    {
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Range(0, 100)]
        public decimal MarksObtained { get; set; }
        [Required]
        public string GradeName { get; set; }
    }


    public class AddMarksModel
    {
        public List<AssignedStudent> AssignedStudents { get; set; }
        public Subject Subject { get; set; }
        public List<Grade> Grades { get; set; }
        public List <Student> Students { get;  set; }
        public List <Mark> AllMarks { get;  set; }
        public Mark Marks { get; set; }
    }
}
