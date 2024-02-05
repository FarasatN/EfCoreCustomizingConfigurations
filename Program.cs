using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace EfCoreShadowProperties
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Ef Core Customizeng Configurations!");
            var context = new AppDbContext();

            //EfCore un default davranislari vardir. Yeri geldikce biz onu deyismek mecburiyyetinde olacagiq
            //Buna gore de elave confiqurasiyalara ehtiyyacimiz olacaq

            //OnModelCreating method - bir model yaradilarken butun konf.+ burdan edilir

            //GetEntityTypes - entityleri elde etmek,ogrenmek ucun ist. edilir - OnModelCreatingin icinde olur
            //cox da aktiv ist. etmesek de, bilmek faydalidi

            //ToTable - DbSetden ferqli ad vermek isteyirsense

            //EGER EYNI VAXTDA FERQLI YANASMALARDAN ISTIFADE OLUNURSA, FLUENT API ESAS GOTURULECEKDIR

            //Column - HasColumnName, HasColumnType, HasColumnOrder
            //Default olaraq propertylerin adi column adi, tipi ise column tipidir, bunu customize ede bilirik bununla

            //ForeignKey/HasForeignKey - Dependant entityde olur
            //eger ist. etmesek shadow properties kimi  arxa planda yene yaradacaq, amma tableda gorunmeyecek

            //Not Mapped - entityde gormek istemediyimiz propertyleri isarelemek ucun ist. edirik
            //Ignore - ise Fluent API versiyasidir.

            //Key - HasKey - default conventio da Id, ID, EntityID kimi proertyler hamisi default olaraq primary key constraint olur
            //Bu property sayesinde biz dc -dan elave istediyimz property ye primary key tetbiq ede bilirik
            // yeni ozumuz PK teyin ede bilirik

            //Timestamp/IsRowVersion - property nin versiyalarini tutur

            //Person p = new();
            //p.Name = "Test";
            //p.Address = new()
            //{
            //    Street = "M. Asad 12",
            //    City = "Sumgayit"
            //};
            //context.Persons.Add(p);
            //await context.SaveChangesAsync();

            //var person = await context.Persons.FindAsync(1);
            //person.Name = "Ahmet";
            //await context.SaveChangesAsync();
            //Console.WriteLine();

            //Required/IsRequired - bir columnun nullable yaxud not null oldugunu konfiqurasiya edirik




        }


        //1 to 1
        //[Table("People")] //with data annotaions
        public class Person
        {
            //[Key]
            //public int Id { get; set; }

            //[Column("ID",TypeName = "string", Order = 3)]
            public int PersonId { get; set; }

            //[NotMapped]
            //public string FirstName { get; set; }
            public string Name { get; set; }

            [Required]
            public string Surname { get; set; }

            // Navigation property for one-to-one relationship
            public Address Address { get; set; }

            //[Timestamp] - ya da fluent api ile
            public byte[] RowVersion { get; set; }

            public DateTime CreatedDate { get; set; }
        }
        public class Address
        {
            public int AddressId { get; set; }
            public string Street { get; set; }
            public string City { get; set; }

            // Navigation property for one-to-one relationship
            public Person Person { get; set; }

            //[ForeignKey("test")]
            //public int test { get; set; }
            public int PersonId { get; set; }

            public DateTime CreatedDate { get; set; }

        }

        //1 to n
        public class Blog
        {
            public int BlogId { get; set; }
            public string Title { get; set; }

            // Navigation property for one-to-many relationship
            public ICollection<Post> Posts { get; set; }

            public DateTime CreatedDate { get; set; }

        }
        public class Post
        {
            public int PostId { get; set; }
            public string Content { get; set; }

            // Foreign key property for one-to-many relationship
            public int BlogId { get; set; }//default conventionda bunu yazmaga ehtiyyac yoxdur, cunki bu shadow properties rolunu oynayir

            // Navigation property for one-to-many relationship
            public Blog Blog { get; set; }

            public DateTime CreatedDate { get; set; }

        }

        //n to n
        public class Book
        {
            public int BookId { get; set; }
            public string Title { get; set; }

            // Navigation property for the many-to-many relationship
            public ICollection<BookAuthor> BookAuthors { get; set; }

            public DateTime CreatedDate { get; set; }

        }
        public class Author
        {
            public int AuthorId { get; set; }
            public string Name { get; set; }

            // Navigation property for the many-to-many relationship
            public ICollection<BookAuthor> BookAuthors { get; set; }

            public DateTime CreatedDate { get; set; }

        }

        // Join entity for the many-to-many relationship
        public class BookAuthor
        {
            public int BookId { get; set; }
            public Book Book { get; set; }

            public int AuthorId { get; set; }
            public Author Author { get; set; }

            public DateTime CreatedDate { get; set; }

        }

        public class AppDbContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCoreCustomizingConfigurations;Trusted_Connection=True;");
            }

            public DbSet<Person> Persons { get; set; }
            public DbSet<Address> Addresses { get; set; }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
            public DbSet<Book> Books { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<BookAuthor> BookAuthors { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

                //1 to 1
                modelBuilder.Entity<Person>()
                .HasOne(p => p.Address)
                .WithOne(a => a.Person)
                .HasForeignKey<Address>(a => a.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Person>()
                .Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")  // Optional: Set the column name
                .HasColumnType("datetime")     // Optional: Set the column data type
                .HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax

                modelBuilder.Entity<Address>()
                .Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")  // Optional: Set the column name
                .HasColumnType("datetime")     // Optional: Set the column data type
                .HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


                //ToTable with Fluent API
                //modelBuilder.Entity<Person>().ToTable("People");

                //Column with Fluent API
                //modelBuilder.Entity<Person>()
                //    .Property(p => p.PersonId)
                //    .HasColumnName("ID")
                //    .HasColumnType("string");

                //HasForeignKey Fluent API - bu zaman ayrica elaqeni de gostermelisen
                //modelBuilder.Entity<Person>()
                //    .HasOne(p => p.Address)
                //    .WithOne(a => a.Person)
                //    .HasForeignKey<Address>(a => a.AddressId);

                //modelBuilder.Entity<Person>()
                //    .Ignore(p => p.FirstName);

                //modelBuilder.Entity<Person>()
                //    .HasKey(p => p.ID);

                //modelBuilder.Entity<Person>()
                //    .Property(p => p.RowVersion)
                //    .IsRowVersion();

                //------------------------------------------------------
                //1 to many
                modelBuilder.Entity<Blog>()
                .HasMany(b => b.Posts)   // One Blog has many Posts
                .WithOne(p => p.Blog)    // Each Post belongs to one Blog
                .HasForeignKey(p => p.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Blog>()
                .Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")  // Optional: Set the column name
                .HasColumnType("datetime")     // Optional: Set the column data type
                .HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax

                modelBuilder.Entity<Post>()
                .Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")  // Optional: Set the column name
                .HasColumnType("datetime")     // Optional: Set the column data type
                .HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


                //------------------------------------------------------
                //many to many
                modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

                modelBuilder.Entity<BookAuthor>()
                .Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")  // Optional: Set the column name
                .HasColumnType("datetime")     // Optional: Set the column data type
                .HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


                modelBuilder.Entity<BookAuthor>()
                    .HasOne(ba => ba.Book)
                    .WithMany(b => b.BookAuthors)
                    .HasForeignKey(ba => ba.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Book>()
                .Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")  // Optional: Set the column name
                .HasColumnType("datetime")     // Optional: Set the column data type
                .HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


                modelBuilder.Entity<BookAuthor>()
                    .HasOne(ba => ba.Author)
                    .WithMany(a => a.BookAuthors)
                    .HasForeignKey(ba => ba.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<Author>()
                .Property(e => e.CreatedDate)
                .HasColumnName("CreatedDate")  // Optional: Set the column name
                .HasColumnType("datetime")     // Optional: Set the column data type
                .HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


                //GetEntityTypes - cox da aktiv ist. etmesek de, bilmek faydalidi
                var entities = modelBuilder.Model.GetEntityTypes();
                foreach (var entity in entities)
                {
                    Console.WriteLine(entity.Name);
                }


                base.OnModelCreating(modelBuilder);

            }
        }

    }


}







