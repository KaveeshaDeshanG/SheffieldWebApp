using System.ComponentModel.DataAnnotations;

namespace SheffieldWebApp.Models

{
    public class Grade
    {
        public int Id { get; set; }

        [Required]
        public string GradeName { get; set; }

        [Required]
        public string SubjectName { get; set; }

        [Range(0, 100)]
        public decimal GivenMarks { get; set; }
    }

}
