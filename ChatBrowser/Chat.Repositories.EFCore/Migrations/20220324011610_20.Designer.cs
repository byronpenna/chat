﻿// <auto-generated />
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
    [Migration("20220324011610_20")]
    partial class _20
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

                    b.ToTable("ChatRooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 3, 23, 19, 16, 10, 359, DateTimeKind.Local).AddTicks(4879),
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 3, 23, 19, 16, 10, 360, DateTimeKind.Local).AddTicks(4569),
                            Name = "Second Chat room"
                        });
                });

            modelBuilder.Entity("Chat.Entities.POCOEntities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("createdDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MessageId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
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
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 3, 23, 19, 16, 10, 361, DateTimeKind.Local).AddTicks(3915),
                            Email = "byronpenna@gmail.com",
                            Password = "cadaefedfef59f3b2eadd7147d4b6891",
                            UserName = "byronpenna"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 3, 23, 19, 16, 10, 361, DateTimeKind.Local).AddTicks(4873),
                            Email = "diana@gmail.com",
                            Password = "cadaefedfef59f3b2eadd7147d4b6891",
                            UserName = "diana_alfaro"
                        });
                });

            modelBuilder.Entity("Chat.Entities.POCOEntities.Message", b =>
                {
                    b.HasOne("Chat.Entities.POCOEntities.ChatRoom", null)
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chat.Entities.POCOEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
