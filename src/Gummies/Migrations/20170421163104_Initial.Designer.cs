using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Gummies.Models;

namespace Gummies.Migrations
{
    [DbContext(typeof(GummiesContext))]
    [Migration("20170421163104_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gummies.Models.Gummy", b =>
                {
                    b.Property<int>("GummyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cost");

                    b.Property<string>("Country");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.HasKey("GummyId");

                    b.ToTable("Gummies");
                });
        }
    }
}
