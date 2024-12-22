using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SheffieldWebApp.Models;

namespace SheffieldWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Grade> Grade { get; set; } = default!;
        public DbSet<Mark> Mark { get; set; } = default!;
        public DbSet<Subject> Subject { get; set; } = default!;
        public DbSet<Student> Student { get; set; } = default!;
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<AssignedStudent> AssignedStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Title = "Biology",
                    Description = "Biology is the scientific study of life and living organisms, including their physical structures, chemical processes, molecular interactions, development, and evolution. Key areas of study include cell biology, genetics, ecology, and biotechnology.",
                },
                new Subject
                {
                    Id = 2,
                    Title = "Chemistry",
                    Description = "Chemistry explores the properties, composition, and behavior of matter. This subject focuses on understanding chemical reactions, the periodic table, molecular structures, and applications in fields like medicine, energy, and materials science."
                },
                new Subject
                {
                    Id = 3,
                    Title = "Physics",
                    Description = "Physics examines the principles governing the universe, including motion, energy, force, and the nature of space and time. Topics range from classical mechanics and thermodynamics to quantum physics and astrophysics."
                },
                new Subject
                {
                    Id = 4,
                    Title = "Mathematics",
                    Description = "Mathematics is a versatile subject that delves into numerical analysis, algebra, calculus, and geometry. It provides tools for modeling and solving problems in science, engineering, finance, and technology."
                },
                new Subject
                {
                    Id = 5,
                    Title = "Computer Science",
                    Description = "Computer Science focuses on understanding and creating software and systems. It encompasses programming, data structures, algorithms, artificial intelligence, cybersecurity, and the development of computational solutions to real-world problems."
                }
                );
        }
    }
}
