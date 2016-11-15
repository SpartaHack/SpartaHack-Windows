using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SpartaHack.BLL.Models;

namespace SpartaHack.BLL.Migrations
{
    [DbContext(typeof(SpartaHackDataStore))]
    [Migration("20161115070031_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509");

            modelBuilder.Entity("SpartaHack.BLL.Models.Schedule", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("location");

                    b.Property<string>("time");

                    b.Property<string>("title");

                    b.Property<string>("updatedAt");

                    b.HasKey("id");

                    b.ToTable("ScheduleItems");
                });

            modelBuilder.Entity("SpartaHack.BLL.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("auth_token");

                    b.Property<string>("email");

                    b.Property<string>("first_name");

                    b.Property<string>("last_name");

                    b.Property<string>("password");

                    b.Property<string>("password_confirmation");

                    b.HasKey("id");

                    b.ToTable("CurrentUser");
                });
        }
    }
}
