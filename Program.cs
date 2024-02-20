using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace EfCoreShadowProperties
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            //for executing speed
            //exetunig started
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //*********************************************


            Console.WriteLine("Ef Core Customizing Configurations!");
            using (var context = new AppDbContext())
            {


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
                //default olaraq eger isare olunmayibsa -  not null/required olacaq
                //Nullable olmasi ucun - ?,
                //Fluent API de - IsRequired deye bolirik

                //MaxLength/ HasMaxLength/ StringLength

                //Percision/HasPrecision - kesirli sayilarda bir deqiqlik yaradan ve noqtenin xanasini bildirmemizi yaradan bir yapilandirmadir
                //[Precision(2,4)] - ya da Fulent API ile


                //Unicode/ IsUniCode - Column icinde unicode characterler olacaqsa
                //[Unicode] - ya da FA ile (IsUnicode)

                //Comment / HasComment -  bezen gerekli olir
                //[Comment("bu bunun ucundur")] - ya da FA ile


                //ConcurrencyCheck / IsConcurrencyToken - bu da RowVersion  kimi data teqib zamani butunluk ucun lazimdir, ileride deyinilecek


                //InverseProperty - 2 entity arasinda birden cox elaqe varsa, bunu deqiqlesdirmek ucundur


                ///////////

                //Composite Key - Tableda birde cox columnun birlesik/elaqeli sekilde primary key olmasini isteyirikse

                //HasDefaultSchema - default olaraq dbo dur, bunu ezir

                //HasDefaultValue - property e default deyer atayir
                //Person person = new()
                //{
                //    Name = "Farasat",
                //    CreatedDate = DateTime.Now,
                //    Address = new()
                //    {
                //        City = "Baku",
                //        Street = "M.Asad,Saray"
                //    }
                //};
                //await context.AddAsync(person);
                //await context.SaveChangesAsync();

                //HasDefaultValueSql- ise default olaraq hansi sql cumlesinden deyeri alacagini teyin edir

                //HasComputedColumn - avtomatik hesablama aparib bir columnda gosterir, excel kimi

                //HasConstraintName() - genelde buna deymesek de, constraintlere name veririk

                //HasData - SeedData ile elaqelidir. Bu baglamda migrate ederken, database yaranarkedn, bir yandan da hazir datalar uzerinden data gondermek lazim olur

                //HasDiscriminator - ileride enityler arasinda toreme elaqelerin oldugu TPT ve TPH adinda movzular olacaq.
                //Bunlarla elaqeli HasDiscriminator ve HasValue metodlaridir

                //A a = new()
                //{
                //    X = "A dan",
                //    Y = 1
                //};
                //B b = new()
                //{
                //    X = "B den",
                //    Z = 2
                //};
                //MyEntity myEntity = new()
                //{
                //    X = "MyEntity den"
                //};

                //context.As.Add(a);
                //context.Bs.Add(b);
                //context.MyEntities.Add(myEntity);
                //context.SaveChanges();


                //HasField - Backing Fileds ozelliyi ile elaqedardir

                //HasNoKey - normalda butun entitylerde primary key olmalidir.Eger olmayacaqsa, bildirilmelidir

                //HasIndex - Sonraki derslerde detalli olaraq incelencek

                //HasQueryFilter - 

                //DatabaseGenerated - irelide Global Query Filter dersinin config.-dir.
                //Esas meqsedi bir entity-e qarsiliq application seviyyesinde bir global filter duzeltmekdir


                //--------------------------------------
                //DatabaseGenerated - ValueGeneratedOnAddOrUpdate, ValueGeneratedOnAdd, ValueGeneratedNever

                //GeneratedValue nedir? - misal ucun, avtomatik primary keyin artmasi, istesek oz isteyimize uygun artar

                //Default Values - table-in her hansi columnuna coding terefinden hec bir deyer gondermesek de, sql terefinde onun yazilacagini ifade edir

                //HasDefaultValue - direct static deyer veririk, hemin deyeri vermesek de avtomatik yazilacaq
                //HasDefaultValueSql - ise sql sorgusu, cumlesi veririk
                //Computed Columns

                //bunlari evvel detalli islemisik!

                //Primary Keys - herhansi bir tableda setirleri kimlik vari sekilde tanidan, unique olan sutun ve ya sutunlardir

                //Identity - ise yalnizca avtomatik olaraq artan sutundur,pk olmaya da biler, ayrica ist. oluna bilir

                //Ef Core da cox vaxt birlikde ist. olunur ve pk hem de identity olur

                //bir table da identity ancaq tek bir defe teyin oluna biler    

                //bir columndan identity ni ayirmaq


                //Random rand = new();

                //for (int i = 0; i <= 10; i++)
                //{
                //    Example exmp = new()
                //    {

                //        X = rand.Next(100),
                //        Y = rand.Next(100),
                //    };
                //    context.Examples.Add(exmp);
                //}
                //Example exmp = new()
                //{
                //    Id = 1,
                //    X = rand.Next(100),
                //    Y = rand.Next(100),
                //};
                //context.Examples.Add(exmp);
                //context.SaveChanges();

                //Execution Time: 5730 milliseconds / 5.73

                //DatabaseGenerated
                //DatabaseGenerated.None - ValueGeneratedNever - deger yaradilmayacaq
                //DatabaseGenerated.Computed - ValueGeneratedOnAddOrUpdate - default deyer yaradilacaqsa
                //DatabaseGenerated.Identity - ardicil sekilde deyer yaradilacaqsa columnda, bir entityde yalniz bir eded ola biler

                //ardicil olmayan zaman ise, meselen guid basqa cur davraniriq

                //demek olar ki, real heyeatda bele bir ssenari ile qarsilasmayacaqsan, hansi ki pk ile identity ayri olsun


                //--------------------------
                //IEntityTypeConfiguration - konfiqurasiyalari xarici fayllara ayirmaq

                //DATA ANNOTAION ILE KONFIQ.+ ESLINDE SOLIDIN SINGLE RESPONSIBILITY PRINSIBINE ZIDDIR
                //amma yene de fluent api ile her seyi yazanda hemin metodun ici cox qarisiq olur
                //buna gore de IEntityType ile Entity temelli bolmekle sadelesdirmek olar

                //OnModelCreating - Entity ler uzerinde konf. deyisiklikleri etdiyimiz Metoddur
                //data annotationda tam butun ozellikler toxdur, ona gore fluent api ile beraber yazmalisan
                //buna gorede de hemin class ile boluruk

                //IEntityTypeConfiguration - umumi konfiqurasiyalar dan basqa, entity ile elaqedar ozelliklerin
                //ayrica classda konf. edir
                //yeni, eneitiye ozel xarici faylda saxlanilir
                //entity cox olanda xarici faylda saxlamaq idareetmeni asanlasdirir

                //esasen Onion architectura kimi boyuk, clean code proyektlerde ist. olunur
                //for exmp: class ExampleConfiguration: IEntityTypeConfiguration<Example>

                //adding data
                Random rand = new();
                for (int i = 0; i <= 1000; i++)
                {
                    Example exmp = new()
                    {
                        X = rand.Next(100),
                        Y = rand.Next(100),
                        ExampleDate = DateTime.Now
                    };
                    await context.Examples.AddAsync(exmp);
                }
                await context.SaveChangesAsync();

                //ApplyConfiguration - edilen konfiqurasiyalari tetbiq edir

                //ApplyConfigurationForAssembly- tek tek konf. i bildirmek yerine umumi konfiqurasilar
                //toplusununun oldugu classi (Assembly) teyin edirik(OnModelCreating icinde edirik, reflection avtomatik tutur)

                //yuxaridaki yazdiqlarimiz best practice ucun tovsiyye olunur
                //CUNKI SINGLE RESPONSIBLE A DA UYGUNDUR


            }
            //****************************
            //executig stopped
            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} milliseconds / {stopwatch.ElapsedMilliseconds / 1000.0}");
            //for exm: Execution Time: 5730 milliseconds / 5.73
            Console.ResetColor();
        }

        //IEntityTypeConfiguration
        public class ExampleConfiguration : IEntityTypeConfiguration<Example>
        {
            public void Configure(EntityTypeBuilder<Example> builder)
            {
                builder.HasKey(ex => ex.Id);
                builder.Property(ex => ex.X).IsRequired().HasMaxLength(7);
                builder.Property(ex => ex.Computed)
                    .HasComputedColumnSql("[X]+[Y]");
                builder.Property(e => e.ExampleCode)
                    .HasDefaultValueSql("NEWID()");
                //.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                //builder.Property(ex => ex.ExampleDate)
                //    .HasDefaultValueSql("GETDATE()");
                builder.Property(ex => ex.ExampleDate)
                .HasColumnType("datetime2(7)"); // Use datetime2 for better precision
                //.HasPrecision(3);
            }
        }

        //HasDiscriminator
        public class MyEntity
        {
            public int Id { get; set; }
            public string X { get; set; }
        }
        public class A : MyEntity
        {
            public int Y { get; set; }
        }
        public class B : MyEntity
        {
            public int Z { get; set; }
        }

        //HasComputedColumn
        public class Example
        {

            //bu numune ile pk ile identityni ayiririq, ama cox ist. olunmur
            [Key]
            //[DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int Id { get; set; }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            //ya da fluent api ile bunu etmek olar
            //public int ExampleCode { get; set; }
            public Guid ExampleCode { get; set; }

            public int X { get; set; }
            public int Y { get; set; }
            public int Computed { get; set; }

            public DateTime ExampleDate { get; set; }
        }


        //1 to 1
        //[Table("People")] //with data annotaions
        public class Person
        {
            //[Key]
            //public int Id { get; set; }

            //[Column("ID",TypeName = "string", Order = 3)]
            [Key]
            public int PersonId { get; set; }
            //for composite key
            [Key]
            public int PersonId2 { get; set; }

            //[ConcurrencyCheck]
            //public int ConcurrencyCheck { get; set; }

            //[NotMapped]
            //public string FirstName { get; set; }
            public string name;
            public string Name { get=>name; set=>name=value; }

            //[Required]
            [MaxLength(13)]
            public string? Surname { get; set; }

            //[Precision(3,2)]
            public double Salary { get;set; }

            // Navigation property for one-to-one relationship
            public Address Address { get; set; }

            //[Timestamp] - ya da fluent api ile
            //public byte[] RowVersion { get; set; }

            [Comment("bu yaradilacaq obyektin tarixini ozunde tutur")]
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
            //[Key]
            public int PersonId { get; set; }
            //for composite key
            //[Key]
            public int PersonId2 { get; set; }

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
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                //1 to 1
                //modelBuilder.Entity<Person>()
                //.HasOne(p => p.Address)
                //.WithOne(a => a.Person)
                //.HasForeignKey<Address>(a => a.PersonId)
                //.OnDelete(DeleteBehavior.Cascade);

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

                //modelBuilder.Entity<Person>()
                //    .Property(p => p.Surname).IsRequired();

                //modelBuilder.Entity<Person>()
                //    .Property(p => p.Surname)
                //    .HasMaxLength(13);

                //modelBuilder.Entity<Person>()
                //    .Property(p => p.Salary)
                //    .HasPrecision(2,3);

                //modelBuilder.Entity<Person>()
                //    .HasComment("bu table ...")
                //    .Property(p => p.Salary)
                //    .HasComment("bu Column ..");

                //modelBuilder.Entity<Person>()
                //    .Property(p => p.ConcurrencyCheck)
                //    .IsConcurrencyCheck();

                //////////////
                //Composite Key
                //modelBuilder.Entity<Person>()
                //    .HasKey(p => new { p.PersonId, p.PersonId2 });

                modelBuilder.Entity<Person>()
                .HasKey(p => new { p.PersonId, p.PersonId2 });
                modelBuilder.Entity<Address>()
                    .HasKey(a => new { a.PersonId, a.PersonId2, a.AddressId });
                modelBuilder.Entity<Person>()
                    .HasOne(p => p.Address)
                    .WithOne(a => a.Person)
                    .HasForeignKey<Address>(ap => new { ap.PersonId, ap.PersonId2 });

                //HasDefaultSchema
                //modelBuilder.HasDefaultSchema("test");

                //HasDefaultValue
                //modelBuilder.Entity<Person>()
                //    .Property(p => p.Salary)
                //    .HasDefaultValue(1000.0);

                //modelBuilder.Entity<Person>()
                //    .Property(p => p.CreatedDate)
                //    //.HasDefaultValue(DateTime.Now);//- bele edib deyer gondere bilerem, amma men sql den almasini isteyirem
                //    .HasDefaultValueSql("GetDate()");

                //HasData
                //modelBuilder.Entity<Person>()
                //.HasData(new Person(new Address());

                modelBuilder.Entity<MyEntity>()
                //.HasDiscriminator<string>("Ayirici");
                .HasDiscriminator<int>("Ayirici")
                .HasValue<A>(1)
                .HasValue<B>(2)
                .HasValue<MyEntity>(3);

                modelBuilder.Entity<Person>()
                    .Property(p => p.Name)
                    .HasField(nameof(Person.name));

                //HasIndex
                //modelBuilder.Entity<Person>()
                //    .HasIndex(p=> new { p.Name, p.Surname });

                //HasQueryFilter
                //modelBuilder.Entity<Person>()
                //    .HasQueryFilter(p => p.CreatedDate.Year==DateTime.Now.Year);


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

                //-----------------------------------------

                //HasComputedColumnSql
                //modelBuilder.Entity<Example>()
                //    .Property(p => p.Computed)
                //    .HasComputedColumnSql("[X]+[Y]");
                //.ValueGeneratedOnAdd();//- ya burdan, ya da data annotat. dan

                //HasNoKey
                //modelBuilder.Entity<Example>()
                //    .HasNoKey();

                //DatabaseGenerated - disabling auto increment for pk, because identity is ExampeCode
                //modelBuilder.Entity<Example>()
                //    .Property(e => e.Id)
                //    .ValueGeneratedNever();

                //modelBuilder.Entity<Example>()
                //    .Property(e => e.ExampleCode)
                //    .HasDefaultValueSql("NEWID()");
                //.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                //modelBuilder.Entity<Example>()
                //    .Property(e => e.ExampleCode)
                //    .ValueGeneratedOnAdd();
                //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] - data annotationun fluent api versiyasidir, eyni seydir

                //-------------------------------------

                //IEntityTypeConfiguration
                //modelBuilder.ApplyConfiguration(new ExampleConfiguration());

                //ApplyConfigurationsFromAssembly
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


                //GetEntityTypes - cox da aktiv ist. etmesek de, bilmek faydalidi
                //var entities = modelBuilder.Model.GetEntityTypes();
                //foreach (var entity in entities)
                //{
                //    Console.WriteLine(entity.Name);
                //}


                base.OnModelCreating(modelBuilder);

            }









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
            public DbSet<Example> Examples { get; set; }
            public DbSet<A> As { get; set; }
            public DbSet<B> Bs { get; set; }
            public DbSet<MyEntity> MyEntities { get; set; }
        }

    }


}







