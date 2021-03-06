// <auto-generated />
using System;
using Chat.Repositories.EFCore.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chat.Repositories.EFCore.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20220319170416_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chat.Entities.POCOEntities.ChatRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChatRoom");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 3, 19, 11, 4, 15, 577, DateTimeKind.Local).AddTicks(3631),
                            Name = "Default"
                        });
                });

            modelBuilder.Entity("Chat.Entities.POCOEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 3, 19, 11, 4, 15, 580, DateTimeKind.Local).AddTicks(5749),
                            Email = "byronpenna@gmail.com",
                            Password = "byronpenna123",
                            UserName = "byronpenna"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 3, 19, 11, 4, 15, 580, DateTimeKind.Local).AddTicks(7070),
                            Email = "diana@gmail.com",
                            Password = "diana123",
                            UserName = "diana_alfaro"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
