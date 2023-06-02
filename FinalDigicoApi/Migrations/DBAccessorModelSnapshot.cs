﻿// <auto-generated />
using FinalDigicoApi.DBAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalDigicoApi.Migrations
{
    [DbContext(typeof(DBAccessor))]
    partial class DBAccessorModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinalDigicoApi.Objects.BasicOccupation", b =>
                {
                    b.Property<string>("selfRef")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("selfRef");

                    b.ToTable("Occupations", (string)null);
                });

            modelBuilder.Entity("FinalDigicoApi.Objects.BasicSkill", b =>
                {
                    b.Property<string>("selfRef")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BasicOccupationselfRef")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BasicOccupationselfRef1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("selfRef");

                    b.HasIndex("BasicOccupationselfRef");

                    b.HasIndex("BasicOccupationselfRef1");

                    b.ToTable("Skill", (string)null);
                });

            modelBuilder.Entity("FinalDigicoApi.Objects.BasicSkill", b =>
                {
                    b.HasOne("FinalDigicoApi.Objects.BasicOccupation", null)
                        .WithMany("essentialSkills")
                        .HasForeignKey("BasicOccupationselfRef");

                    b.HasOne("FinalDigicoApi.Objects.BasicOccupation", null)
                        .WithMany("optionalSkills")
                        .HasForeignKey("BasicOccupationselfRef1");
                });

            modelBuilder.Entity("FinalDigicoApi.Objects.BasicOccupation", b =>
                {
                    b.Navigation("essentialSkills");

                    b.Navigation("optionalSkills");
                });
#pragma warning restore 612, 618
        }
    }
}
