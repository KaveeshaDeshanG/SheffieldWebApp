namespace SheffieldWebApp.Models

{
    public class Student
    {
        public int Id { get; set; }
        public string RegistrationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int GradeId { get; set; }
    }
}
