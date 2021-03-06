// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api_rest.Persistence.Context;

namespace api_rest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("api_rest.Domain.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("IdCategory");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            IdCategory = 100,
                            Name = "Fruits and Vegetables"
                        },
                        new
                        {
                            IdCategory = 101,
                            Name = "Dairy"
                        });
                });

            modelBuilder.Entity("api_rest.Domain.Models.Product", b =>
                {
                    b.Property<int>("IdProduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdCategory")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<short>("QuantityInPackage")
                        .HasColumnType("smallint");

                    b.Property<byte>("UnitOfMeasurement")
                        .HasColumnType("smallint");

                    b.HasKey("IdProduct");

                    b.HasIndex("IdCategory");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            IdProduct = 100,
                            IdCategory = 100,
                            Name = "Apple",
                            QuantityInPackage = (short)1,
                            UnitOfMeasurement = (byte)1
                        },
                        new
                        {
                            IdProduct = 101,
                            IdCategory = 101,
                            Name = "Milk",
                            QuantityInPackage = (short)2,
                            UnitOfMeasurement = (byte)5
                        });
                });

            modelBuilder.Entity("api_rest.Domain.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.HasKey("IdUser");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            IdUser = 1,
                            Login = "LucasMaia",
                            Name = "Lucas",
                            Password = "12345"
                        },
                        new
                        {
                            IdUser = 2,
                            Login = "MateusTales",
                            Name = "Mateus",
                            Password = "98765"
                        });
                });

            modelBuilder.Entity("api_rest.Domain.Models.Product", b =>
                {
                    b.HasOne("api_rest.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("api_rest.Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
