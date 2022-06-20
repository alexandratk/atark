﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalityIdentification.DataContext;

namespace PersonalitylID.Migrations
{
    [DbContext(typeof(MyDataContext))]
    [Migration("20220505191923_add_marks")]
    partial class add_marks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupLesson", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("LessonsId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "LessonsId");

                    b.HasIndex("LessonsId");

                    b.ToTable("GroupLesson");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Administrator");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Administrator");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.EducationalInstitution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Timetable")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Audience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dateoffinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dateofstart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EducInstId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.MovingPupil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int?>("PupilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("PupilId");

                    b.ToTable("MovingPupil");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.MovingTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("TeacherId");

                    b.ToTable("MovingTeacher");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EducInstId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Parent");

                    b.HasKey("Id");

                    b.ToTable("Parent");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Pupil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Pupil");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Pupil");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.PupilParent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("PupilId")
                        .HasColumnType("int");

                    b.Property<string>("Relationship")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("PupilId");

                    b.ToTable("PupilParent");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Dateofbirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EducationalInstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Teacher");

                    b.HasKey("Id");

                    b.HasIndex("EducationalInstitutionId");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("GroupLesson", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalityIdentification.DataContext.Lesson", null)
                        .WithMany()
                        .HasForeignKey("LessonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Administrator", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Administrators")
                        .HasForeignKey("EducationalInstitutionId");

                    b.Navigation("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Device", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Devices")
                        .HasForeignKey("EducationalInstitutionId");

                    b.Navigation("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Group", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Groups")
                        .HasForeignKey("EducationalInstitutionId");

                    b.HasOne("PersonalityIdentification.DataContext.Teacher", "Teacher")
                        .WithMany("Groups")
                        .HasForeignKey("TeacherId");

                    b.Navigation("EducationalInstitution");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Lesson", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.Teacher", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.MovingPupil", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.Device", "Device")
                        .WithMany("MovingPupils")
                        .HasForeignKey("DeviceId");

                    b.HasOne("PersonalityIdentification.DataContext.Pupil", "Pupil")
                        .WithMany("MovingPupils")
                        .HasForeignKey("PupilId");

                    b.Navigation("Device");

                    b.Navigation("Pupil");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.MovingTeacher", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.Device", "Device")
                        .WithMany("MovingTeachers")
                        .HasForeignKey("DeviceId");

                    b.HasOne("PersonalityIdentification.DataContext.Teacher", "Teacher")
                        .WithMany("MovingTeachers")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Device");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Pupil", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.Group", "Group")
                        .WithMany("Pupils")
                        .HasForeignKey("GroupId");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.PupilParent", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.Parent", "Parent")
                        .WithMany("PupilParents")
                        .HasForeignKey("ParentId");

                    b.HasOne("PersonalityIdentification.DataContext.Pupil", "Pupil")
                        .WithMany("PupilParents")
                        .HasForeignKey("PupilId");

                    b.Navigation("Parent");

                    b.Navigation("Pupil");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Teacher", b =>
                {
                    b.HasOne("PersonalityIdentification.DataContext.EducationalInstitution", "EducationalInstitution")
                        .WithMany("Teachers")
                        .HasForeignKey("EducationalInstitutionId");

                    b.Navigation("EducationalInstitution");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Device", b =>
                {
                    b.Navigation("MovingPupils");

                    b.Navigation("MovingTeachers");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.EducationalInstitution", b =>
                {
                    b.Navigation("Administrators");

                    b.Navigation("Devices");

                    b.Navigation("Groups");

                    b.Navigation("Teachers");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Group", b =>
                {
                    b.Navigation("Pupils");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Parent", b =>
                {
                    b.Navigation("PupilParents");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Pupil", b =>
                {
                    b.Navigation("MovingPupils");

                    b.Navigation("PupilParents");
                });

            modelBuilder.Entity("PersonalityIdentification.DataContext.Teacher", b =>
                {
                    b.Navigation("Groups");

                    b.Navigation("Lessons");

                    b.Navigation("MovingTeachers");
                });
#pragma warning restore 612, 618
        }
    }
}
