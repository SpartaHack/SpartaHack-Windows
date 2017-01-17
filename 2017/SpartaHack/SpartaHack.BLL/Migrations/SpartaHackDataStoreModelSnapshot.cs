using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SpartaHack.BLL.Models;

namespace SpartaHack.BLL.Migrations
{
    [DbContext(typeof(SpartaHackDataStore))]
    partial class SpartaHackDataStoreModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509");

            modelBuilder.Entity("SpartaHack.BLL.Models.Prize", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<int?>("sponsorid");

                    b.HasKey("id");

                    b.HasIndex("sponsorid");

                    b.ToTable("Prizes");
                });

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

            modelBuilder.Entity("SpartaHack.BLL.Models.Sponsor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("level");

                    b.Property<string>("logo_png_dark");

                    b.Property<string>("logo_png_light");

                    b.Property<string>("logo_svg_dark");

                    b.Property<string>("logo_svg_light");

                    b.Property<string>("name");

                    b.Property<string>("url");

                    b.HasKey("id");

                    b.ToTable("Sponsors");
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

            modelBuilder.Entity("SpartaHack.BLL.Models.Prize", b =>
                {
                    b.HasOne("SpartaHack.BLL.Models.Sponsor", "sponsor")
                        .WithMany()
                        .HasForeignKey("sponsorid");
                });
        }
    }
}
