using Microsoft.EntityFrameworkCore;

namespace PersonalityIdentification.DataContext
{
    public class MyDataContext : DbContext
    {
        
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Pupil> Pupil { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<PupilParent> PupilParent { get; set; }
        public DbSet<MovingPupil> MovingPupil { get; set; }
        public DbSet<MovingTeacher> MovingTeacher { get; set; }
        public DbSet<EducationalInstitution> EducationalInstitution { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Mark> Mark { get; set; }


        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
            Database.Migrate();
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Administrators).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Teachers).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Groups).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<EducationalInstitution>().HasMany(t => t.Devices).WithOne(p => p.EducationalInstitution);
            modelBuilder.Entity<Device>().HasMany(t => t.MovingPupils).WithOne(p => p.Device);
            modelBuilder.Entity<Pupil>().HasMany(t => t.MovingPupils).WithOne(p => p.Pupil);
            modelBuilder.Entity<Device>().HasMany(t => t.MovingTeachers).WithOne(p => p.Device);
            modelBuilder.Entity<Teacher>().HasMany(t => t.MovingTeachers).WithOne(p => p.Teacher);
            modelBuilder.Entity<Pupil>().HasMany(t => t.PupilParents).WithOne(p => p.Pupil);
            modelBuilder.Entity<Parent>().HasMany(t => t.PupilParents).WithOne(p => p.Parent);
            modelBuilder.Entity<Group>().HasMany(t => t.Pupils).WithOne(p => p.Group);
            modelBuilder.Entity<Group>().HasMany(t => t.Lessons).WithMany(p => p.Groups);
            modelBuilder.Entity<Teacher>().HasMany(t => t.Groups).WithOne(p => p.Teacher);
            modelBuilder.Entity<Teacher>().HasMany(t => t.Lessons).WithOne(p => p.Teacher);
            modelBuilder.Entity<Lesson>().HasMany(t => t.Marks).WithOne(p => p.Lesson);
            modelBuilder.Entity<Pupil>().HasMany(t => t.Marks).WithOne(p => p.Pupil);
            


            modelBuilder.Entity<Teacher>().Property(r => r.Role).HasDefaultValue("Teacher");
            modelBuilder.Entity<Pupil>().Property(r => r.Role).HasDefaultValue("Pupil");
            modelBuilder.Entity<Parent>().Property(r => r.Role).HasDefaultValue("Parent");
            modelBuilder.Entity<Administrator>().Property(r => r.Role).HasDefaultValue("Administrator");
        }
    }
}