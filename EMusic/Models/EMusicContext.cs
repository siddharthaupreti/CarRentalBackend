using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EMusic.Models
{
    public partial class EMusicContext : DbContext
    {
        public EMusicContext()
        {
        }

        public EMusicContext(DbContextOptions<EMusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<EnrollmentApplication> EnrollmentApplications { get; set; } = null!;
        public virtual DbSet<Faculty> Faculties { get; set; } = null!;
        public virtual DbSet<Institute> Institutes { get; set; } = null!;
        public virtual DbSet<InstituteRating> InstituteRatings { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<LessonEnrollment> LessonEnrollments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeacherApplication> TeacherApplications { get; set; } = null!;
        public virtual DbSet<TeacherFaculty> TeacherFaculties { get; set; } = null!;
        public virtual DbSet<TeacherRating> TeacherRatings { get; set; } = null!;
        public virtual DbSet<TeacherSchool> TeacherSchools { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=EMusic");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.TeacherSchoolId).HasColumnName("TeacherSchoolID");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.TeacherSchool)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherSchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_TeacherSchool");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");

                entity.Property(e => e.EnrollmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("EnrollmentID");

                entity.Property(e => e.CompletedDate).HasColumnType("date");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.EnrollmentApplicationId).HasColumnName("EnrollmentApplicationID");

                entity.Property(e => e.StartedDate).HasColumnType("date");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.EnrollmentApplication)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.EnrollmentApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enrollment_EnrollmentApplication");
            });

            modelBuilder.Entity<EnrollmentApplication>(entity =>
            {
                entity.ToTable("EnrollmentApplication");

                entity.Property(e => e.EnrollmentApplicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("EnrollmentApplicationID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.SubmittedDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.EnrollmentApplications)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnrollmentApplication_Course");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.EnrollmentApplications)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EnrollmentApplication_Student");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("Faculty");

                entity.Property(e => e.FacultyId)
                    .ValueGeneratedNever()
                    .HasColumnName("FacultyID");

                entity.Property(e => e.FacultyName).HasMaxLength(50);
            });

            modelBuilder.Entity<Institute>(entity =>
            {
                entity.ToTable("Institute");

                entity.Property(e => e.InstituteId)
                    .ValueGeneratedNever()
                    .HasColumnName("InstituteID");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.EstablishedYear).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Institutes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Institute_Users");
            });

            modelBuilder.Entity<InstituteRating>(entity =>
            {
                entity.ToTable("InstituteRating");

                entity.Property(e => e.InstituteRatingId)
                    .ValueGeneratedNever()
                    .HasColumnName("InstituteRatingID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.InstituteId).HasColumnName("InstituteID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.InstituteRatings)
                    .HasForeignKey(d => d.InstituteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstituteRating_Institute");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.InstituteRatings)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstituteRating_Student");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.LessonId)
                    .ValueGeneratedNever()
                    .HasColumnName("LessonID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lessons_Course");
            });

            modelBuilder.Entity<LessonEnrollment>(entity =>
            {
                entity.ToTable("LessonEnrollment");

                entity.Property(e => e.LessonEnrollmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("LessonEnrollmentID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.LessonEnrollments)
                    .HasForeignKey(d => d.EnrollmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LessonEnrollment_Enrollment");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.LessonEnrollments)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LessonEnrollment_Lessons");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Users");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.TeacherId)
                    .ValueGeneratedNever()
                    .HasColumnName("TeacherID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_Users");
            });

            modelBuilder.Entity<TeacherApplication>(entity =>
            {
                entity.ToTable("TeacherApplication");

                entity.Property(e => e.TeacherApplicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("TeacherApplicationID");

                entity.Property(e => e.InstituteId).HasColumnName("InstituteID");

                entity.Property(e => e.SubmittedDate).HasColumnType("date");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Institute)
                    .WithMany(p => p.TeacherApplications)
                    .HasForeignKey(d => d.InstituteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherApplication_Institute");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherApplications)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherApplication_Teacher");
            });

            modelBuilder.Entity<TeacherFaculty>(entity =>
            {
                entity.ToTable("TeacherFaculty");

                entity.Property(e => e.TeacherFacultyId)
                    .ValueGeneratedNever()
                    .HasColumnName("TeacherFacultyID");

                entity.Property(e => e.FacultyId).HasColumnName("FacultyID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.TeacherFaculties)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherFaculty_Faculty");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherFaculties)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherFaculty_Teacher");
            });

            modelBuilder.Entity<TeacherRating>(entity =>
            {
                entity.ToTable("TeacherRating");

                entity.Property(e => e.TeacherRatingId)
                    .ValueGeneratedNever()
                    .HasColumnName("TeacherRatingID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TeacherRatings)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherRating_Student");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherRatings)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherRating_Teacher");
            });

            modelBuilder.Entity<TeacherSchool>(entity =>
            {
                entity.ToTable("TeacherSchool");

                entity.Property(e => e.TeacherSchoolId)
                    .ValueGeneratedNever()
                    .HasColumnName("TeacherSchoolID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.TeacherActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TeacherApplicationId).HasColumnName("TeacherApplicationID");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.TeacherApplication)
                    .WithMany(p => p.TeacherSchools)
                    .HasForeignKey(d => d.TeacherApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherSchool_TeacherApplication");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UpdatedDate).HasColumnType("date");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
