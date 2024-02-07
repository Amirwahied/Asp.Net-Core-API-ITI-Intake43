using Microsoft.EntityFrameworkCore;

namespace CRUDLectureExample.Model
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Adjust Your connection string here
            //optionsBuilder.UseSqlServer("");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Department> Departments { get; set; }

    }
}
