﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using myProjectsPortfolio.Models;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace myProjectsPortfolio.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20181111185450_myMigration")]
    partial class myMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("myProjectsPortfolio.Models.AngAuto", b =>
                {
                    b.Property<int>("AngAuto_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("projectName");

                    b.Property<string>("thePath");

                    b.HasKey("AngAuto_ID");

                    b.ToTable("AngAutos");
                });

            modelBuilder.Entity("myProjectsPortfolio.Models.Install", b =>
                {
                    b.Property<int>("Install_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AngAuto_ID");

                    b.Property<string>("TheInstall");

                    b.HasKey("Install_ID");

                    b.HasIndex("AngAuto_ID");

                    b.ToTable("Installs");
                });

            modelBuilder.Entity("myProjectsPortfolio.Models.Job", b =>
                {
                    b.Property<int>("Job_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("applied");

                    b.Property<string>("company");

                    b.Property<DateTime?>("date");

                    b.Property<string>("description");

                    b.Property<string>("epoch");

                    b.Property<string>("legal");

                    b.Property<string>("logo");

                    b.Property<string>("position");

                    b.Property<string>("slug");

                    b.Property<string>("url");

                    b.HasKey("Job_ID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("myProjectsPortfolio.Models.Joined", b =>
                {
                    b.Property<int>("Joined_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Job_ID");

                    b.Property<int>("User_ID");

                    b.HasKey("Joined_ID");

                    b.HasIndex("Job_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Joineds");
                });

            modelBuilder.Entity("myProjectsPortfolio.Models.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordC");

                    b.HasKey("User_ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("myProjectsPortfolio.Models.Install", b =>
                {
                    b.HasOne("myProjectsPortfolio.Models.AngAuto", "AngAuto")
                        .WithMany()
                        .HasForeignKey("AngAuto_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("myProjectsPortfolio.Models.Joined", b =>
                {
                    b.HasOne("myProjectsPortfolio.Models.Job", "Job")
                        .WithMany("Joineds")
                        .HasForeignKey("Job_ID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("myProjectsPortfolio.Models.User", "User")
                        .WithMany("Joineds")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
