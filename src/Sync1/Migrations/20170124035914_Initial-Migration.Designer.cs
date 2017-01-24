using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Sync1.Contexto;

namespace Sync1.Migrations
{
    [DbContext(typeof(CompanyContext))]
    [Migration("20170124035914_Initial-Migration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sync1.Model.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int?>("ManagerID");

                    b.HasKey("EmployeeID");

                    b.HasIndex("ManagerID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Sync1.Model.Employee", b =>
                {
                    b.HasOne("Sync1.Model.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerID");
                });
        }
    }
}
