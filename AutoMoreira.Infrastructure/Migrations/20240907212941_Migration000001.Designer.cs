﻿// <auto-generated />
using System;
using AutoMoreira.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoMoreira.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240907212941_Migration000001")]
    partial class Migration000001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutoMoreira.Core.Domains.ClientMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint")
                        .HasColumnName("phone_number");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.ToTable("client_messages", (string)null);
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_default");

                    b.Property<bool>("IsReadOnly")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_read_only");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "24118ee3-7631-4f8d-8e7d-19c5cf885042",
                            IsDefault = true,
                            IsReadOnly = true,
                            Name = "Administrador",
                            NormalizedName = "ADMINISTRADOR"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "1f36a64d-1351-4b3b-8684-b1db1f50f18c",
                            IsDefault = true,
                            IsReadOnly = false,
                            Name = "Colaborador",
                            NormalizedName = "COLABORADOR"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "13f41f84-fdbc-4004-8816-65c680da350e",
                            IsDefault = false,
                            IsReadOnly = false,
                            Name = "Comercial",
                            NormalizedName = "COMERCIAL"
                        });
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<bool>("DarkMode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("dark_mode");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("email_confirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("Image")
                        .HasColumnType("text")
                        .HasColumnName("image");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_default");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<bool>("LockoutEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b7c8fd47-1b1d-4c5b-87b2-6cd23c5d7024",
                            DarkMode = false,
                            Email = "automoreiraportugal@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Auto",
                            IsDefault = true,
                            LastName = "Moreira",
                            LockoutEnabled = false,
                            NormalizedEmail = "AUTOMOREIRAPORTUGAL@GMAIL.COM",
                            NormalizedUserName = "AUTOMOREIRAPORTUGAL@GMAIL.COM",
                            PhoneNumber = "231472555",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "dcc08757-b7c5-4dc7-8af3-4f21d8d051be",
                            TwoFactorEnabled = false,
                            UserName = "automoreiraportugal@gmail.com"
                        });
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("user_roles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("marks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Audi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 3,
                            Name = "BMW"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Peugeot"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Citroën"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Volvo"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Fiat"
                        });
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MarkId")
                        .HasColumnType("integer")
                        .HasColumnName("mark_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("MarkId");

                    b.ToTable("models", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MarkId = 1,
                            Name = "A3"
                        },
                        new
                        {
                            Id = 2,
                            MarkId = 2,
                            Name = "Classe A"
                        },
                        new
                        {
                            Id = 3,
                            MarkId = 3,
                            Name = "Serie 1"
                        },
                        new
                        {
                            Id = 4,
                            MarkId = 4,
                            Name = "308"
                        },
                        new
                        {
                            Id = 5,
                            MarkId = 5,
                            Name = "Golf"
                        },
                        new
                        {
                            Id = 6,
                            MarkId = 6,
                            Name = "C4"
                        },
                        new
                        {
                            Id = 7,
                            MarkId = 7,
                            Name = "Megane"
                        },
                        new
                        {
                            Id = 8,
                            MarkId = 8,
                            Name = "V40"
                        },
                        new
                        {
                            Id = 9,
                            MarkId = 9,
                            Name = "Punto"
                        });
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<int>("Doors")
                        .HasColumnType("integer")
                        .HasColumnName("doors");

                    b.Property<int>("EngineSize")
                        .HasColumnType("integer")
                        .HasColumnName("engine_size");

                    b.Property<int>("FuelType")
                        .HasColumnType("integer")
                        .HasColumnName("fuel_type");

                    b.Property<int>("Mileage")
                        .HasColumnType("integer")
                        .HasColumnName("mileage");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer")
                        .HasColumnName("model_id");

                    b.Property<string>("Observations")
                        .HasColumnType("text")
                        .HasColumnName("observations");

                    b.Property<bool>("Opportunity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("opportunity");

                    b.Property<int>("Power")
                        .HasColumnType("integer")
                        .HasColumnName("power");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<bool>("Sold")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("sold");

                    b.Property<DateTime?>("SoldDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("sold_date");

                    b.Property<int>("Transmission")
                        .HasColumnType("integer")
                        .HasColumnName("transmission");

                    b.Property<string>("Version")
                        .HasColumnType("text")
                        .HasColumnName("version");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("vehicles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Azul",
                            Doors = 5,
                            EngineSize = 1999,
                            FuelType = 2,
                            Mileage = 2000,
                            ModelId = 1,
                            Observations = "Garantia de 2 anos",
                            Opportunity = true,
                            Power = 140,
                            Price = 40000.0,
                            Sold = false,
                            Transmission = 1,
                            Version = "Sportline",
                            Year = 2022
                        },
                        new
                        {
                            Id = 2,
                            Color = "Cinza",
                            Doors = 5,
                            EngineSize = 1999,
                            FuelType = 3,
                            Mileage = 7000,
                            ModelId = 2,
                            Observations = "Garantia de 2 anos",
                            Opportunity = true,
                            Power = 140,
                            Price = 27000.0,
                            Sold = false,
                            Transmission = 2,
                            Version = "AMG",
                            Year = 2021
                        },
                        new
                        {
                            Id = 3,
                            Color = "Vermelho",
                            Doors = 5,
                            EngineSize = 1999,
                            FuelType = 1,
                            Mileage = 0,
                            ModelId = 3,
                            Observations = "Garantia de 2 anos",
                            Opportunity = true,
                            Power = 140,
                            Price = 29000.0,
                            Sold = false,
                            Transmission = 2,
                            Version = "Sport",
                            Year = 2023
                        },
                        new
                        {
                            Id = 4,
                            Color = "Verde",
                            Doors = 5,
                            EngineSize = 1999,
                            FuelType = 1,
                            Mileage = 10000,
                            ModelId = 4,
                            Observations = "Garantia de 2 anos",
                            Opportunity = false,
                            Power = 140,
                            Price = 18000.0,
                            Sold = false,
                            Transmission = 1,
                            Version = "GTI",
                            Year = 2022
                        });
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.VehicleImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMain")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_main");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("url");

                    b.Property<int>("VehicleId")
                        .HasColumnType("integer")
                        .HasColumnName("vehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("vehicle_images", (string)null);
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Visitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Month")
                        .HasColumnType("integer")
                        .HasColumnName("month");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.Property<int>("Year")
                        .HasColumnType("integer")
                        .HasColumnName("year");

                    b.HasKey("Id");

                    b.ToTable("visitors", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("identity_role_claim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("identity_user_claim", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("identity_user_login", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("identity_user_token", (string)null);
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Identity.UserRole", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Identity.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoMoreira.Core.Domains.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Model", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Mark", "Mark")
                        .WithMany("Models")
                        .HasForeignKey("MarkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mark");
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Vehicle", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Model", "Model")
                        .WithMany("Vehicles")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.VehicleImage", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Vehicle", "Vehicle")
                        .WithMany("VehicleImages")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AutoMoreira.Core.Domains.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Mark", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Model", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("AutoMoreira.Core.Domains.Vehicle", b =>
                {
                    b.Navigation("VehicleImages");
                });
#pragma warning restore 612, 618
        }
    }
}
