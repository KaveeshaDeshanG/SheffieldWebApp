using System.ComponentModel.DataAnnotations;

namespace SheffieldWebApp.Models
{
    public class Teacher
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string subject { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Qulification { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
    }
}
