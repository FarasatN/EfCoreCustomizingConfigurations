using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using static EfCoreShadowProperties.Program;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                //Random rand = new();
                //for (int i = 0; i <= 1000; i++)
                //{
                //    Example exmp = new()
                //    {
                //        X = rand.Next(100),
                //        Y = rand.Next(100),
                //        ExampleDate = DateTime.Now
                //    };
                //    await context.Examples.AddAsync(exmp);
                //}
                //await context.SaveChangesAsync();

                //ApplyConfiguration - edilen konfiqurasiyalari tetbiq edir

                //ApplyConfigurationForAssembly- tek tek konf. i bildirmek yerine umumi konfiqurasilar
                //toplusununun oldugu classi (Assembly) teyin edirik(OnModelCreating icinde edirik, reflection avtomatik tutur)

                //yuxaridaki yazdiqlarimiz best practice ucun tovsiyye olunur
                //CUNKI SINGLE RESPONSIBLE A DA UYGUNDUR

                //====================================
                //Seed Data ozelligi -hazir datalarla birlikde db nin formalasdrirlimasi ucundur
                //meselen: default deyerin verilmesi de seed datadir

                //Data Seeding asagidaki hallarda onemlidir:
                //Test ucun data lazimdirsa
                //asp.net core identity konf.daki kimi static deyerler de tutulabiler
                //proqramlasdirma ucun temel konf. deyerler ucun

                //seed data elave etmek

                //tutaq ki Blog uzerinden Seed Data elave edirik(OnModelCreating icinde)
                //HasData() - bu metod sayesinde icra edirik

                //Seed Data da pk ler manuel olaraq verilmelidir mutleq
                //bunu vermesen mutleq xeta verecek

                //!!!!!!!!
                //her hansi pk i deyismek istesek eger evvelki migrationlar qalibsa onlara baxacq ve cascade ederek ona uygun diger tabledaki datalari da silecek, ama eger butun migrationlari silmisikse, onda ise xeta verecek, cunki neye uygun sileceyini bilmeyecek

                //amma dependant table uzerinde istediyini deyise bilersen, ona uygun update edecek digerini de

                //SEED DATALAR YALNIZCA MIGRATION ZAMANI GEREKLIDIR

                //====================================
                //Entity inheritance

                //var querySql = context.Database.ExecuteSql($"select * from Examples");
                //Console.WriteLine(querySql.ToString());

                //1. Table Per Hierarchy (TPH) - burda hersye tek classin icinde olur ve, "DISCRIMINATOR" ile ayrilir
                //tutaq ki bizim classlarimiz var: Person, Employee, Customer, Technician
                //ve bunlar arasinda: Person<-Customer && Employee<-Technician elaqesi var
                //ve butun columnlar bir class icinde olacaqlar
                //Persons{Person(Id,Name, Surname), Discriminator, Customer(CompanyName), Employee(Department), Technician(Branch)}

                //2. Table Per Type (TPT) - burda her birini ayrica yaradacaq entitylerinve ust base e baglayacaq
                //nisbeten cox az istifade olunur

                //3. Table Per Concrete Type (TPC) -  Ef Core 7 ile gelib
                //yuxaridakilarda base classlar abstract ola bilerdi, burda ise direkt abstract olur
                //ferqi odur ki:
                //TPT de her type e uygun entity, burda ise concrete type e entity olacaq, abstract olana table olmayacaq
                //Base Clasdaki/abstract clasdaki columnlar hamisinda olacaq, amma hamsina aid olacaq


                //TPH (with discriminator)
                //eyni columnlarin oldugu entityleri discriminatorla ayiririq
                //EF CORE DEFAULT OLARAQ BUNU TETBIQ EDIR,yeni elave konf. ehtiyca yoxdur

                //tph de nullable olmalidir ki columnlar, bezilerinde olmasa data xeta vermesin, tekce pk den basqa
                //ve discriminatordan basqa

                //base classi abstract da ede bilerik

                //Discriminator nedir - ef core terefinden avtomatik table a yerlestirilir,
                //default olaraq icerisinde entity name lerini saxlayir
                //bu columunu istenilen kimi customize etmek mumkundur

                //meselen: discriminatorun adini deyismek ucun fluent api de konf. edilir

                //var emp1 = new Employee() { Name = "Farasat", Surname = "Novruzov",Department="IT" };
                //var emp2 = new Employee() { Name = "Magsad", Surname = "Novruzov",Department="IT" };
                //var cus1 = new Customer() { Name = "X", Surname = "XX",CompanyName="XXXXX" };
                //var cus2 = new Customer() { Name = "XY", Surname = "XXYY",CompanyName="XXXYYY" };
                //var tec1 = new Technician() { Name = "XYZ", Surname = "XXYYZZ",Branch="XXXYYYZZZ" };

                //Employee? empl = await context.Employees.FindAsync(2);
                //context.Employees.Remove(empl);

                //update de sade qaydada olacaq

                //await context.Employees.AddRangeAsync(emp1);
                //await context.Employees.AddRangeAsync(emp2);
                //await context.Customers.AddRangeAsync(cus1);
                //await context.Customers.AddRangeAsync(cus2);
                //await context.Technicians.AddRangeAsync(tec1);
                //await context.SaveChangesAsync();

                //TPH  3. NORMAL FORMA ZIDDIR!!

                //TPH NIN ISTIFADE YERLERI: ECOMMERCE APPDA YAZDIGIMIZ KIMI, FERQLI FERQLI FILE TIPLERINI SAXLAMAQ UCUN BU COX YARARLIDIR
                //FILES(Id,FileName,Path, Storage, Discriminator, Price, Showcase, CreatedDate)

                //SORGULAMA ZAMANI, EGER UST SINIF CAGIRIIBSA, ALTDAKILAR DA GELECEK, AMMA ALT SINIFDE ISE ANCAQ OZU GELECEK


                //---------
                //TPT - her entity ye bir classda olur ve hiyerarxiye uygun elaqelendirir bunu
                //bu da cox istifade olunmur, demek olar gormeyeceksen

                //Technician? tec = new() { Name = "Farasat", Surname = "Novruzov", Department = "IT", Branch = "Back End" };

                //Customer? cust = new()
                //{
                //    Name = "Mardan",
                //    Surname = "Novruzov",
                //    CompanyName = "MN",
                //};

                //Customer? cust = await context.Customers.FindAsync(2);
                //Person? pers = await context.Persons.FindAsync(3);
                //Technician? tec = await context.Technicians.FindAsync(1);
                //botov elaqeli oldugu datani getirecek
                //tec.Name = "Maqsad";
                //await context.Customers.AddAsync(cust);
                //context.Persons.Remove(pers);
                //var a  = pers;
                //await context.SaveChangesAsync();

                //Mentiq olaraq Efcore da demek olar istifade olunmur

                //EGER PERFORMANCE ESAS KRITERIYADIRSA, O ZAMAN TPH,
                //NORMALIZASIYA QAYDALARINA UYGUN ISE TPt

                //TPC - ancaq concrete classlarin table i yaranacaq, yeni abstract in table i olmayacaq
                //evveline nisbeten join sayi azaldigi ucun, performans artacaq
                //tpc - de personun clumnlari her concrete classda ayrica eks olunacaq

                //add, update, delete - evvelkilerle oxsardir
                //await context.Technicians.AddAsync(new() { Name = "Farasat", Surname = "Novruzov", Branch = "Development",Department = "IT" });
                //await context.Technicians.AddAsync(new() { Name = "Magsad", Surname = "Novruzov", Branch = "Development",Department = "IT" });
                //await context.Technicians.AddAsync(new() { Name = "Mardan", Surname = "Novruzov", Branch = "Development",Department = "IT" });
                //await context.SaveChangesAsync();

                //delete, update de eyni qaydada

                //=================================
                //Constraints - columuna olan mehdudiyyet ve sertler

                //Primary Key - HasKey/Key - Fluent API/Data Annotation

                //Normalda eger classda Id, NameId ve s. olarsa, onu avtomatik PK edecek
                //Yox, eger ferqli bir adda columnu PK etmek ucun ise, atrbibutlar ile isareleyirik

                //Alternate Keys
                //PK e elave olaraq alternative bir key yaradir

                //Alternate key - db de unique keydir
                //bununla unique composite key de yarada bilirik fluent api de

                //PK in default name ini deyismek

                //qalanlari fluent apide ..

                //====================================
                //Indexes

                //PK. FK ve AK avtomatik olaraq indekslenir

                //Index/HasIndex ile icra olunur

                //indeksleme odur ki, bu column uzerinden yalniz sorgularda daha suretli performance elde olunur
                // context.Employees.Where(e => e.Name == "");//amma elave Surnamei de elave etsem mailyyeti artacaq
                //bunun qarsisini almaq ucun composite etmek olar 2 sini

                //Unique Indexes - constraint de elave edir ki, tekrar olmasin

                //Index Sort Order - ef core 7-den sonra gelib
                //AllDescending - ancaq bir property ucun
                //IsDescending - ise bir metod icinde ferqli ferqli property ucun

                //Index Filter - attributu yoxdur, ancaq fluent api dedi

                //Included Columns - complex sorgularda, indexden kenar olanlari da bura elave edib performans qazanmaq ucun

                //  BASDAN HER SEYI FLUENT APIDE YAZMAQ EN YAXSISIDIR


                //===============================
                //Sequence - db de benzersiz ve ardicil deyerler yaradan db obyektidir
                //Sequence- herhansi bir table in ozelligi deyil, db obyektidir.Birden cox table terefinden ist. oluna biler

                //HasSquence ile Fluent Api de konf. edilir
                //modelBuilder.HasSequence("EC_Sequence");


                //SEQUENCE - avtomatik artan deyerler yaradir
                //Sequence - identityden daha suretli ve performancslidi, cunki diskden yox, ramdan alir
                //Sequence - db obyektidir, identity ise table ozelliyi
                //Sequence - herhansi table a bagli deyildir




                //===========================================================================
                //===========================================================================
                //Loading Datas

                //Eager Loading - relational datalarin parca parca yuklenmesini iradeli sekilde teskil edir
                //eager - yeni, istekli loading

                //include ile tetbiq olunur, hisse hisse table lar birlesdirilir
                //var employees = await context.Employees.ToListAsync();
                //Console.WriteLine();
                //normalda burda diger elaqeli tablelar olmur, cunki, hec neyi daxil etmemisik

                //var employees1 = await context.Employees.Include("Orders").ToListAsync();// - bu tip esasen shadow propetiesde ist. olunur
                //var employees2 = await context.Employees
                //    .Where(e => e.Orders.Count() > 0)
                //    .Include(e=>e.Orders)
                //    .Include(e=>e.Region)
                //    .ToListAsync();
                //Console.WriteLine();
                //Eager Loading arxa planda "uygun" joini tetbiq edir

                //ThenInclude
                //var orders = await context.Orders
                //    //.Include(o => o.Employee)
                //    .Include(o => o.Employee.Region)//anceq tek olan property uzerinden mumkundur
                //    .ToListAsync();

                //misal ucun asagidaki numunede bu mumkun deyil
                //var regions = await context.Regions
                //    .Include(r=>r.Employees)//single level
                //    .ThenInclude(e=>e.Orders).ToListAsync();//multilevel 

                //https://mertsoyer.com/ef-core-include-theninclude-nedir/
                //yeni, 1 to many elaqesinde mutleq ThenInclude() olacaq


                //Filtered Include - adindan gorunduyu kimi filterlenmis include neticesini getirir
                //var regions = await context.Regions
                //    .Include(r => r.Employees.Where(e=>e.Name.Contains("a"))
                //    .OrderByDescending(e=>e.Name))
                //    .ToListAsync();

                //ChangeTraker olunmus datalarda Include dogru netice vermiye biler,yeni filterden kenarda qalanlar track olunacaq
                //Buna gore de, change tracker olmamalidir, filter ederken


                //Qeyd!!!
                //Eager Loading heddinden artiq istifade olundugu ucun, xirda optimizasiyalar cox onemlidir
                //Ef Core onceden yaradilmis vs execute edilerek in memory e getirilmis datalari sonraki islemlerde ist. edir
                //misal ucun:
                //var orders = await context.Orders.ToListAsync();
                //var employees = await context.Employees.ToListAsync();
                //employees icerisinde include etmesek de evvelki sorgudan qalma Orders ler de gelir yaddasdan
                //yeni, her sorgunun neticesi in memory de qalir ve istifadeye hazirdir

                //AutoInclude - cekilen datada mutleq sekilde include olacaqsa, ayri ayri qeyd etmekdense, bunu yaziriq
                //merkezi formada

                //IgnoreAutoIncludes - legv edir AutoInclude u

                //Bir birinden innerit almis Entitylerde Include
                //Cast, as, overload


                //============================================
                //Explicit Loading
                //Eager kimi hamisini Include etmir, ehtiyaca gore edir, lazimsiz join olmur

                //var employee = await context.Employees.Include(e => e.Orders).FirstOrDefaultAsync(e=>e.Id==5);
                //Include maliyyetini azaltmaq ucun asag
                //var employee = await context.Employees.Include(e => e.Orders).FirstOrDefaultAsync(e=>e.Id==5);
                //if (employee.Name == "Farasat")
                //{
                //    var orders = await context.Orders.Where(o=>o.EmployeeId==employee.Id).ToListAsync();
                //}

                //Reference - collection olmayan tablelari sonradan sorguya join edir
                //var empl = await context.Employees.FirstOrDefaultAsync(e => e.Id == 5);
                //await context.Entry(empl).Reference(e => e.Region).LoadAsync();

                //Collection -  referencin collection formasidir
                ////var empl = await context.Employees.FirstOrDefaultAsync(e => e.Id == 6);
                ////var count = await context.Entry(empl).Collection(e => e.Orders).Query().CountAsync();
                ////var orders = await context.Entry(empl).Collection(e => e.Orders).Query().Where(q=>q.OrderDate.Day==DateTime.Now.Day).ToListAsync();
                //birbasa burdan uzerinde aggregate isleri aparmaq olur, evvelki


                //===============================
                //Lazy Loading - ..
                //Navigation property uzerinden emeliyyat aparan zaman elaqeli properti uzerinden qarsiliq gelen tablea uygun sorgunun yazilib execute edilmesidir

                //var emp = await context.Employees.FindAsync(5);
                //Console.WriteLine(emp.Region.Name); ;//normalda bu null excep. atacaq,
                //amma bis bunu bildirsek ki lazy olacaq sekilde region ucun arxa planda sorgu yaratsin ve bazaya qosulsun, onda yox

                //Proxy ile Lazy Loading - bizler en cox bunu proxyde istf edirik
                //Amma tekce optionsBuilder ile is bitmir
                //Navigatio propertiler virtual olmalidir, yoxsa xeta verecek

                //ne vaxt istifade olunmalidir:
                //https://stackoverflow.com/questions/31366236/lazy-loading-vs-eager-loading

                //Proxyler butun platformlarda desteklenmeyebiler, buna gore de manuel olaraq lazy loaadingi tetbiq etmek gerekecek

                //ILazyLoader interface-i
                //Manuel loadingde virtuale ehtiyyac yoxdur
                //var employee = await context.Employees.FindAsync(1);

                //Delegate ile Lazy Loading

                //N+1 problemi - her dongu ucun ayrica sorgu yaradacaq, bu da cox maliyyetlidir
                //Ona gore de lazy loadingden mumkun qeder uzaq durmaq lazimdir, xususile dongusel islerde

                //Console.WriteLine();

                //====================================================
                //Complex Query Operators : Joins

                //Join
                //Query Syntax
                //var query = from photo in context.Photos
                //            join person in context.Persons
                //            on photo.PersonId equals person.Id
                //            select new
                //            {
                //               person.Name,
                //               photo.FilePath,
                //            };
                //var datas = await query.ToListAsync();


                //Method Syntax
                //var query = context.Photos
                //    .Join(context.Persons,
                //    photo => photo.PersonId,
                //    person => person.Id,
                //    (photo, person) => new
                //    {
                //        person.Name,
                //        photo.FilePath
                //    });
                //var datas = await query.ToListAsync();

                //Console.WriteLine();

                ////Multiple columns join
                //var query = from photo in context.Photos
                //            join person in context.Persons
                //            on new { photo.PersonId, photo.FilePath } equals new { PersonId = person.Id, FilePath = person.Name }
                //            select new
                //            {
                //                person.Name,
                //                photo.FilePath
                //            };
                //var datas = await query.ToListAsync();

                //eynile method syntax

                //2 den cox table ile islemek
                //Query Syntax
                //var query = from photo in context.Photos
                //            join person in context.Persons
                //                on photo.PersonId equals person.PersonId
                //            join order in context.Orders
                //                on person.PersonId equals order.PersonId
                //            select
                //            //photo;
                //            //person;
                //            new
                //            {
                //                person.Name,
                //                photo.FilePath,
                //                order.Id,
                //                order.OrderDate
                //            };
                //var datas = await query.ToListAsync();

                //method syntax
                //var query = context.Photos
                //    .Join(context.Persons,
                //    photo => photo.PersonId,
                //    person => person.PersonId,
                //    (photo, person) => new
                //    {
                //        person.PersonId,
                //        person.Name,
                //        photo.FilePath
                //    }
                //    )
                //    .Join(context.Orders,
                //    oncekiSorgu => oncekiSorgu.PersonId,
                //    order => order.PersonId,
                //    (oncekiSorgu, order) => new
                //    {
                //        oncekiSorgu.Name,
                //        oncekiSorgu.FilePath,
                //        order.Id,
                //        order.OrderDate
                //    }
                //    );
                //var datas = query.ToList();

                //Group Join, not Group By
                //Query Syntax
                //var query = from person in context.Persons
                //            join order in context.Orders
                //                on person.PersonId equals order.PersonId into personOrders
                //            from order in personOrders
                //            select new
                //            {
                //                person.Name,
                //                //Count = personOrders.Count(),
                //                order.OrderDate,
                //                order.Id
                //            };
                //var datas = await query.ToListAsync();

                //Joins

                //Left Join - sol teref tam gosterilir, varsa elaqesi olan deyerler sagdakinda, yaninda gosterilir
                //left, ya da Right joinde ancaq QUERY syntax ist. ede bilirik

                //var query = from person in context.Persons
                //            join order in context.Orders
                //               on person.PersonId equals order.PersonId into personOrders
                //            from order in personOrders.DefaultIfEmpty()
                //            select
                //            new
                //            {
                //                person.Name,
                //                order.Description
                //            };
                //var datas = await query.ToListAsync();

                //DefaultIfEmpty() - left joini yaradan ve cagiran funksiyadir


                //Right Join- Ef Core da Riht Join yarada bilmirik, amma bu mentiqle emeliyyat apara bilirik
                //yeni, left joini ters cevirib sorgu yaratmaqla

                //var query = from order in context.Orders
                //            join person in context.Persons
                //               on person.PersonId equals order.PersonId into ordersPersons
                //            from order in ordersPersons.DefaultIfEmpty()
                //            select
                //            new
                //            {
                //                person.Name,
                //                order.Description
                //            };
                //var datas = await query.ToListAsync();

                //Full Join - Ef Core bunu da desteklemir,ama bunu da dolayisi ile etmek olur
                //once Left Join, sonra tersine Left Join(Right Join) edib birlesdiririk

                //var queryLeft = from person in context.Persons
                //            join order in context.Orders
                //               on person.PersonId equals order.PersonId into personOrders
                //            from order in personOrders.DefaultIfEmpty()
                //            select
                //            new
                //            {
                //                person.Name,
                //                order.Description
                //            };
                //var queryRight = from order in context.Orders
                //            join person in context.Persons
                //               on order.PersonId equals person.PersonId into ordersPersons
                //            from person in ordersPersons.DefaultIfEmpty()
                //            select
                //            new
                //            {
                //                person.Name,
                //                order.Description
                //            };
                //var fullJoin = queryLeft.Union(queryRight);
                //var datas = await fullJoin.ToListAsync();

                //Cross Join - Cartedian join,1. tabledaki her setir 2. ye uygun yeresdirlir
                //var query = from order in context.Orders
                //            from person in context.Persons
                //            select new
                //            {
                //                order,
                //                person,
                //            };
                //var datas = await query.ToListAsync();


                //Where - cross joinde bununla inner join etmek olu meselen
                //var query = from order in context.Orders
                //            from person in context.Persons where(p=>p.PersonId == order.PersonId)
                //            select new
                //            {
                //                order,
                //                person,
                //            };


                //Cross Apply
                //var query = from order in context.Orders
                //            from person in context.Persons.Select(p=>order.Description)
                //            select new
                //            {
                //                order,
                //                person,
                //            };
                //var datas = await query.ToListAsync();

                //Outer Apply



                //---------------------------------------------------
                //Raw Sql ile calismaq
                //Eger ki, sorgunuzu LINQ ile ifade ede bilmezsinizse, yahut da linqin etdiyinden daha optimize bir sorguyu manual 
                //yazmaq ve ef core uzerinden execute etmek isteyirsinizse, ef core un bu davranisi bu davranisi deskteklediyini 
                //bilmekde fayda var

                //Query Execute

                //FromSqlInterpolated - before EfCore7.0
                //bunun ucun sorgu ucun ona uygun model dbsetde qeyd olunmalidir mutleq
                //Formatible string ile sorgu yazilmalidir

                //var persons = await context.Persons.FromSqlInterpolated($"select * from Persons").ToListAsync();

                //FromSql - EfCore7.0 
                //var persons = await context.Persons.FromSql($"select * from Persons").ToListAsync();

                //Stored Procedure Execute - eyni qaydada store proceduru da calisdira bilirik

                //Parametrli Sorgu 1
                //int personId = 3;
                //var persons = await context.Persons.FromSql($"select * from Persons where PersonId= {personId}").ToListAsync();

                //Parametrli Sorgu 1
                //SqlParameter personId = new("PersonId","3");//tekce bunu da vermek olur
                //personId.DbType = System.Data.DbType.Int32;
                //personId.Direction = System.Data.ParameterDirection.Input;
                //var persons = await context.Persons.FromSql($"select * from Persons where PersonId= {personId}").ToListAsync();


                //Dynamic Sql yaratma - FromSqlRaw
                //string columnName = "", value = "";
                //var persons = await context.Persons.FromSql($"select * from Persons where {columnName}={value}").ToListAsync();
                //bu qaydada mumkun deyil,cunki column adi parametrlesib

                //asagidaki kimi mumkundur ancaq:
                //string columnName = "PersonId";
                //SqlParameter value = new("PersonId", "3");
                //var persons = await context.Persons.FromSqlRaw($"select * from persons where {columnName}=@PersonId",value).ToListAsync();
                //burda da sql injection xeberdarligi yaranacaq, mesuliyyet developere qalir


                //SqlQuery - Entity olmayan scalar sorgularin calisdirilmasini temin edir
                //tek bir columnda datalarin geldiyi sorgularda ist. olunur, hansisa entity cagirmaga ehtiyyac yoxdur

                //var data = await context.Database.SqlQuery<int>($"select PersonId from Persons").ToListAsync();

                //var data = await context.Database.SqlQuery<int>($"select PersonId value from Persons")//vale yazilmalidir
                //    .Where(personId=>personId>2)
                //    .ToListAsync();

                //ExecuteSql - unsert, update, delete
                //bu komanda ile saveChangesi cagirmaga ehtiyyac yoxdur
                //amma orm uzerinden etmek tovsiyye olunur
                //await context.Database.ExecuteSqlAsync($"update Persons set name='FarasatN' where PersonId=1");

                //Mehdudiyyetler
                //butun columnlar cagirilmalidir,yalniz birini cagirsan xeta atacaq

                //sutun adi ile property adi eyni olmalidir

                //Join mumkun deyil,xeta verecek, include gerekdir


                //--------------------------------------------
                //View - nedir
                //Yaratdigimiz kompleks sorgulari, ehtiyac duydugumuzda daha rahat bir sekilde ist. etmek ucun 
                //sadelesdiren db obyektidir
                //her defe ist. olunan agir sorgulari xirda view de bolub saxlamaq olur, performans ve zaman baximindan

                //View yaratmaq:
                //View i bos migration yaradib icine yazilir, update olunur
                //Sonra ise Dbset olaraq entity yaradilir ve cagirilir db contextde

                //var personOrders = await context.PersonOrders
                //    .Where(po=>po.Count>1)
                //    .ToListAsync();

                //view de pk olmaz, buna gore de hasnokey ile isarelenir

                //ChangeTracker burda islemeyecek, deyisiklikleri db ye yansitmaz

                //view table formasinda deyerler dondurur

                //--------------------------------------------
                //Store Procedure - viewde ferqli olaraq parametrli deyer donduren bir nov funksiyadir

                //VIEW VE STORE PROCEDURELARI EF CORE OZU BILMIR, BIZ ONA MIGRATIONDA BILDIRMELIYIK BUNU

                //1. yene de bos migration icinde konf. edilir, update edilir
                //2. fromsql ile ist. olunur

                //var datas = await context.PersonOrders.FromSql($"exec sp_PersonOrders").ToListAsync();

                //ef core mecbur edir ki sorgulari orm olaraq entity ile qarsilayasan,
                //dapper ise ele deyil

                //store procedure da bir entity e mutleq qarsiliq gelmelidir

                //geriye deger donduren store procedure ist. etme
                //SqlParameter sqlParameter = new()
                //{
                //    ParameterName = "count",
                //    SqlDbType = System.Data.SqlDbType.Int,
                //    Direction = System.Data.ParameterDirection.Output
                //}; 
                //await context.Database.ExecuteSqlRawAsync($"exec @count =  sp_BestSellingStaff");

                //inpute ve output in store procedure
                //---------------------
                //                --use EfCoreCustomizingConfigurations
                //create procedure sp_BestSellingStaff(
                //                @CustomPersonId int, --defaul olara inputdur(input)
                //    @CustomName nvarchar(max)
                //)
                //as
                //                declare @name nvarchar(max), @count int
                //    select @name = p.Name,@CustomName = p.Name output, @count = count(*) from Persons p
                //    join Orders o
                //        on p.PersonId = o.PersonId
                //    where p.PersonId = @@CustomPersonId
                //                                                                         group by p.Name
                //    order by count(*) desc
                //    return @count--geriye sayisal deyer gelmelidi
                //    --print(@name)
                //declare @CustomName nvarchar(max)
                //exec sp_PersonOrders 3, @CustomName output
                //go

                //declare @count int
                //exec @count = sp_BestSellingStaff
                //select @count

                //SqlParameter nameParameter = new()
                //{
                //    ParameterName = "name",
                //    SqlDbType = System.Data.SqlDbType.NVarChar,
                //    Direction = System.Data.ParameterDirection.Output,
                //    Size = 1000
                //};
                //await context.Database.ExecuteSqlRawAsync($"execute sp_BestSellingStaff 3, @CustomName");

                //Console.WriteLine(nameParameter.Value);

                //-------------------------------------------------
                //Scalar ve Inline funksiyalarin Ef Core da istifadesi

                //Scalar - geriye deyer donduren funksiyadir
                //Scalar funks. yaratmaq:
                //1. bos bir migration yaradlilir
                //2. bunun icerisinde Up metodu icinde Sql metodu ile Create kodlari yazilacaq, Down icinde de Drop kodlari yazilacaq
                //3. migrate edilir

                //var persons = await (from person in context.Persons
                //              where context.GetPersonTotalOrderPrice(person.PersonId) > 5
                //              select person).ToListAsync();

                //var persons = context.GetPersonTotalOrderPrice(1);


                //Inline - Geriye yalniz table donduren funksiyalardir
                //1. bos migration yarat
                //2. burda konf. edilir
                //sql terefde hamisi eyni qaydada, sadece "int", "string" yerine "table" yazacagiq

                //var persons = await context.BestSellingStaff(3000).ToListAsync();

                //Console.WriteLine();


                //----------------------------------------------------------
                //Database Prperty-si - manual advanced seviyyede konf. ucundur
                //misal ucun:

                //Normalda transactionu ef core oz uzerine goturur

                //BeginTransaction - anliq manual mudaxile etmek istesek
                //IDbContextTransaction transaction = context.Database.BeginTransaction();//bu instans ile ozumuz idare edirik
                //transaction.Commit();

                //CommitTransaction - manual uzerinde is etmemek ucun ise budur
                //context.Database.CommitTransaction();

                //RollBackTransaction - edilen islerin rol back edilmesi ucundur
                //context.Database.RollbackTransaction();

                //CanConnect - db ile baglanti yaradila bileceyini bool ile yoxlayir
                //bool conect = context.Database.CanConnect();
                //Console.WriteLine(conect);

                //EnsureCreated - cox onremlidir.migration olmadan db ni yaradir
                //context.Database.EnsureCreated();
                //var isDeleted = context.Database.EnsureDeleted();//runtime migration olmadan silir
                //Console.WriteLine(isDeleted);


                //GenerateCretaeScript - db nin sql kodlarini script kimi verir
                //var script = context.Database.GenerateCreateScript();
                //Console.WriteLine(script);

                //ExecuteSql - only for INSERT, UPDATE, DELETE, or DDL (Data Definition Language) statements.
                //For Select - FromSqlRaw(ef7+), FromSqlInterpolated

                //var person = context.Database.ExecuteSql($"select p.Name, p.Gender from Persons p");
                //Console.WriteLine(person);

                //ExecuteSql - default olaraq sql injectiondan qoruyur,amma ExecuteSqlRaw yox
                //cunki string interpolation yoxdur ve oldugu kimi db ye sorgu gedir, digerinde ise convert olunur
                //yeni, raw tehlukesiz deyil

                //var person = context.Database.ExecuteSql($"delete Persons where PersonId=1");
                //Console.WriteLine(person);


                //SqlQuery/SqlQueryRaw, evezine FromSql ist. olunur
                //context.Database.SqlQuery()


                //GetAppliedMigrations - eger migrationlari elde edib, haradasa ist. edeceyikse
                //var migs = context.Database.GetMigrations();//runtime da elde edirik

                //EN GUNCEL, AKTIV OLANI MIGRATIONlari GOSTERIR ANCAQ, yeni, apply olmuslari
                //Console.WriteLine();

                //GetPendingMigrations - apply olunmmamislari getirir

                //Migrate - runtime da migrate edir
                //context.Database.Migrate();//sona qeder migrate edir, Allah ne verdiyse ;)

                ////EnsureCreated vs Migrate!!!
                ///EnsureCreated - migrationlari ehate etmir

                //OpenConnection - db ile connection acir
                //CloseConnection - baglayir
                //context.Database.OpenConnection();
                //context.Database.CloseConnection();

                //GetConnectionString - elaqeli contex obketinin un o anda istifade etdiyi Connection Stringi gosterir
                //Console.WriteLine(context.Database.GetConnectionString());

                //GetDbConnection - Ef coreun esasi olan Ado.Netin ist. etdiyi DbConnection obyektini
                //elde etmeye komek eden funksiydir, yeni AdoNete aparir
                //DbConnection connection = context.Database.GetDbConnection();
                //SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();//casting
                //Console.WriteLine();

                //SetDbConnection - customize connectionlari daxil edirik
                //context.Database.SetDbConnection(....);

                //Providername - hansi sql provideri ist. edirik
                // Console.WriteLine(context.Database.ProviderName);//~ Microsoft.EntityFrameworkCore.SqlServer


                //----------------------------------
                //Keyless Entity Types
                //Normal entity lere elave olaraq PK i olmayan query lere qarsi db sorgulari yaratmaq ucundur

                //umumilikde statistiksel emeliyyatlarin group by ve yaxud pivot table ile yaradilan tablellarda pk olmur
                //onlari KET ile qarsilaya bilerik

                //view formatinda qarsilayacaq entity yaradib db setde elave edirik
                //bos migration yaradib sql kodlari up/down da konfiq edirik
                //sonra OnModelCreating de keysin view oldugunu config edirik
                //HasNoKey evezine [Keyless] eyni mahiyyet dasiyir
                //PK kesinlikle olmayacaq
                //Change Tracker aktiv deyildir
                //Yalnizca TPH mumkundur,diferleri yox

                //var datas = await context.PersonOrderCounts.ToListAsync();
                //Console.WriteLine();

                //-------------------------------------------------------------------------
                //Logging - calisan bir sistemin runtime da nece davrandigini gostermek ucun Log mexanizmlarindan istifade olunur

                //Neleri Loglayiriq
                //Ef Core da - lazimi sorgulari loglayiriq, hessas datalari da hemcinin
                //Log - "gunluk" menasina gelir

                //Sade log numunesi, nuget paketine ehtiyyac yoxdur

                //Normalda console dan loga baxmaq izlenilebilir deyildir,
                //ona gore de xarici fayllarda saxlamaq en dogrusudur

                //Hessas datalarin logu
                //EfCore default olaraq herhansi datanin degerini gostermir, tehlukesizlik prinsipine uygun
                //amma bezen datanin deyerini bilmek gereke biler, ayird etmek ucun
                //EnableSensitiveDataLogging() - bu imkani bize yaradir
                
                //Exceptionlari loglama, detalli olaraq - EnableDetailedErrors

                //LOGUN ONEMI-BAZA ILE ELAQE ITE BILER, BUNU BURDAN OYRENE BILERIK

                //EfCore default olaraq debugin ustundeki butun levelleri loglayir
                //asagida bunu da deyise bilirik

                var persons = await context.Persons.ToListAsync();
                foreach (var item in persons)
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();

            }
            //****************************
            //executig stopped
            stopwatch.Stop();
            Console.WriteLine($"Execution Time: {stopwatch.ElapsedMilliseconds} milliseconds / {stopwatch.ElapsedMilliseconds / 1000.0} seconds");
            //for exm: Execution Time: 5730 milliseconds / 5.73
            Console.ResetColor();
        }

        public class PersonOrderCount
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        //tph, tpt, tpc

        //base class abstract yaxud concrete ola biler
        //indexing - class seviyyesinde ist. olunur, ya da fluent api ile
        //[Index(nameof(Name))]
        //Compossite Indexes
        //[Index("Name","Surname")]

        //[Index(nameof(Name))] //context.Person.Where(e=>e.Name=="..")   
        //[Index(nameof(Surname))] //context.Person.Where(e=>e.Surname=="..") 
        //[Index(nameof(Name),nameof(Surname))]//context.Person.Where(e=>e.Name==".." || e.Name=="..") 
        //yuxaridaki her biri ayridir

        ////Unique Index
        //[Index(nameof(Name),IsUnique = true)]
        ////
        //[Index(nameof(Name), IsUnique = true,AllDescending = true)]
        //[Index(nameof(Name), nameof(Surname), IsDescending = new[] {true,false},Name = "MyIndex")]//in fluent api HasDatabaseName
        //abstract public class Person
        //{
        //    public int Id { get; set; }
        //    public string? Name { get; set; }
        //    public string? Surname { get; set; }

        //}
        //public class Employee: Person
        //{
        //    public string? Department { get; set; }
        //}
        //public class Customer: Person
        //{
        //    public string? CompanyName { get; set; }
        //}
        //public class Technician: Employee
        //{
        //    //C# 12 - new primary constructor feature
        //    //public Technician(string name = "IT Technician")
        //    //{
        //    //    Console.WriteLine(name);
        //    //}
        //    public string? Branch { get; set; }
        //}

        //IEntityTypeConfiguration
        //public class ExampleConfiguration : IEntityTypeConfiguration<Example>
        //{
        //    public void Configure(EntityTypeBuilder<Example> builder)
        //    {
        //        builder.HasKey(ex => ex.Id);
        //        builder.Property(ex => ex.X).IsRequired().HasMaxLength(7);
        //        builder.Property(ex => ex.Computed)
        //            .HasComputedColumnSql("[X]+[Y]");
        //        builder.Property(e => e.ExampleCode)
        //            .HasDefaultValueSql("NEWID()");
        //        //.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        //        //builder.Property(ex => ex.ExampleDate)
        //        //    .HasDefaultValueSql("GETDATE()");
        //        builder.Property(ex => ex.ExampleDate)
        //        .HasColumnType("datetime2(7)"); // Use datetime2 for better precision
        //        //.HasPrecision(3);
        //    }
        //}

        ////HasDiscriminator
        //public class MyEntity
        //{
        //    public int Id { get; set; }
        //    public string X { get; set; }
        //}
        //public class A : MyEntity
        //{
        //    public int Y { get; set; }
        //}
        //public class B : MyEntity
        //{
        //    public int Z { get; set; }
        //}

        ////HasComputedColumn
        //public class Example
        //{
        //    //bu numune ile pk ile identityni ayiririq, ama cox ist. olunmur
        //    [Key]
        //    //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //    public int Id { get; set; }

        //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //    //ya da fluent api ile bunu etmek olar
        //    //public int ExampleCode { get; set; }
        //    public Guid ExampleCode { get; set; }

        //    public int X { get; set; }
        //    public int Y { get; set; }
        //    public int Computed { get; set; }

        //    public DateTime ExampleDate { get; set; }
        //}


        //1 to 1
        //[Table("People")] //with data annotaions
        //public class Person
        //{
        //    //[Key]
        //    //public int Id { get; set; }

        //    //[Column("ID",TypeName = "string", Order = 3)]
        //    [Key]
        //    public int PersonId { get; set; }
        //    //for composite key
        //    [Key]
        //    public int PersonId2 { get; set; }

        //    //[ConcurrencyCheck]
        //    //public int ConcurrencyCheck { get; set; }

        //    //[NotMapped]
        //    //public string FirstName { get; set; }
        //    public string name;
        //    public string Name { get=>name; set=>name=value; }

        //    //[Required]
        //    [MaxLength(13)]
        //    public string? Surname { get; set; }

        //    //[Precision(3,2)]
        //    public double Salary { get;set; }

        //    // Navigation property for one-to-one relationship
        //    public Address Address { get; set; }

        //    //[Timestamp] - ya da fluent api ile
        //    //public byte[] RowVersion { get; set; }

        //    [Comment("bu yaradilacaq obyektin tarixini ozunde tutur")]
        //    public DateTime CreatedDate { get; set; }
        //}
        //public class Address
        //{
        //    public int AddressId { get; set; }
        //    public string Street { get; set; }
        //    public string City { get; set; }

        //    // Navigation property for one-to-one relationship
        //    public Person Person { get; set; }

        //    //[ForeignKey("test")]
        //    //public int test { get; set; }
        //    //[Key]
        //    public int PersonId { get; set; }
        //    //for composite key
        //    //[Key]
        //    public int PersonId2 { get; set; }

        //    public DateTime CreatedDate { get; set; }
        //}

        //1 to n
        //public class Blog
        //{
        //    public int BlogId { get; set; }
        //    public string Title { get; set; }

        //    // Navigation property for one-to-many relationship
        //    public ICollection<Post> Posts { get; set; }

        //    public DateTime CreatedDate { get; set; }

        //}
        //public class Post
        //{
        //    public int PostId { get; set; }

        //    //for composite keyor fluent api
        //    //[ForeignKey(nameof(Blog))]
        //    public string Content { get; set; }

        //    // Foreign key property for one-to-many relationship
        //    [ForeignKey(nameof(Blog))]
        //    public int BlogId { get; set; }//default conventionda bunu yazmaga ehtiyyac yoxdur, cunki bu shadow properties rolunu oynayir

        //    // Navigation property for one-to-many relationship
        //    public Blog Blog { get; set; }

        //    public DateTime CreatedDate { get; set; }

        //}

        ////n to n
        //public class Book
        //{
        //    public int BookId { get; set; }
        //    public string Title { get; set; }

        //    // Navigation property for the many-to-many relationship
        //    public ICollection<BookAuthor> BookAuthors { get; set; }

        //    public DateTime CreatedDate { get; set; }

        //}
        //public class Author
        //{
        //    public int AuthorId { get; set; }
        //    public string Name { get; set; }

        //    // Navigation property for the many-to-many relationship
        //    public ICollection<BookAuthor> BookAuthors { get; set; }

        //    public DateTime CreatedDate { get; set; }

        //}

        //// Join entity for the many-to-many relationship
        //public class BookAuthor
        //{
        //    public int BookId { get; set; }
        //    public Book Book { get; set; }

        //    public int AuthorId { get; set; }
        //    public Author Author { get; set; }

        //    public DateTime CreatedDate { get; set; }

        //}

        //=================================================
        //=================================================




        //public class Employee
        //{
        //    //Action<object, string> _lazyLoader;
        //    //Region _region;
        //    //public Employee() { }
        //    //public Employee(Action<object, string> lazyLoader)
        //    //    => _lazyLoader = lazyLoader;

        //    public int Id { get; set; }
        //    public int RegionId { get; set; }
        //    public string Name { get; set; }
        //    public string? Surname { get; set; }
        //    public int Salary { get; set; }
        //    public  List<Order> Orders { get; set; }
        //    public virtual Region Region { get; set; }

        //    //public Region Region
        //    //{
        //    //    get => _lazyLoader.Load(this, ref _region);
        //    //    set => _region = value;
        //    //}
        //}
        //public class Region
        //{
        //    //Action<object, string> _lazyLoader;
        //    //ICollection<Employee> _employees;
        //    //public Region() { }
        //    //public Region(Action<object, string> lazyLoader)
        //    // => _lazyLoader = lazyLoader;
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public virtual ICollection<Employee> Employees { get; set; }

        //    //public ICollection<Employee> Employees
        //    //{
        //    //    get => _lazyLoader.Load(this, ref _employees);
        //    //    set => _employees = value;
        //    //}
        //}
        //public class Order
        //{
        //    public int Id { get; set; }
        //    public int EmployeeId { get; set; }
        //    public DateTime OrderDate { get; set; }

        //    public virtual Employee Employee { get; set; }
        //}

        //=================

        public class Person
        {
            public int PersonId { get; set; }
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public ICollection<Order> Orders { get; set; }
            public Photo Photo { get; set; }
        }

        public enum Gender
        {
            Man,
            Woman
        }

        public class Order
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }
            public int PersonId { get; set; }
            public Person Person { get; set; }
        }

        public class Photo
        {
            public int Id { get; set; }
            public string FilePath { get; set; }
            public int PersonId { get; set; }
            public Person Person { get; set; }
        }

        [NotMapped]
        public class PersonOrder
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }

        public class BestSellingStaff
        {
            public string Name { get; set; }
            public int OrderCount { get; set; }
            public double TotalOrderPrice { get; set; }
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

                //modelBuilder.Entity<Person>()
                //.Property(e => e.CreatedDate)
                //.HasColumnName("CreatedDate")  // Optional: Set the column name
                //.HasColumnType("datetime")     // Optional: Set the column data type
                //.HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax

                //modelBuilder.Entity<Address>()
                //.Property(e => e.CreatedDate)
                //.HasColumnName("CreatedDate")  // Optional: Set the column name
                //.HasColumnType("datetime")     // Optional: Set the column data type
                //.HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


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

                //modelBuilder.Entity<Person>()
                //.HasKey(p => new { p.PersonId, p.PersonId2 });
                //modelBuilder.Entity<Address>()
                //    .HasKey(a => new { a.PersonId, a.PersonId2, a.AddressId });
                //modelBuilder.Entity<Person>()
                //    .HasOne(p => p.Address)
                //    .WithOne(a => a.Person)
                //    .HasForeignKey<Address>(ap => new { ap.PersonId, ap.PersonId2 });

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

                //modelBuilder.Entity<MyEntity>()
                ////.HasDiscriminator<string>("Ayirici");
                //.HasDiscriminator<int>("Ayirici")
                //.HasValue<A>(1)
                //.HasValue<B>(2)
                //.HasValue<MyEntity>(3);

                //modelBuilder.Entity<Person>()
                //    .Property(p => p.Name)
                //    .HasField(nameof(Person.name));

                //HasIndex
                //modelBuilder.Entity<Person>()
                //    .HasIndex(p=> new { p.Name, p.Surname });

                //HasQueryFilter
                //modelBuilder.Entity<Person>()
                //    .HasQueryFilter(p => p.CreatedDate.Year==DateTime.Now.Year);


                //------------------------------------------------------
                //1 to many
                //modelBuilder.Entity<Blog>()
                //.HasMany(b => b.Posts)   // One Blog has many Posts
                //.WithOne(p => p.Blog)    // Each Post belongs to one Blog
                //.HasForeignKey(p => p.BlogId)
                //.OnDelete(DeleteBehavior.Cascade);

                //modelBuilder.Entity<Blog>()
                //.Property(e => e.CreatedDate)
                //.HasColumnName("CreatedDate")  // Optional: Set the column name
                //.HasColumnType("datetime")     // Optional: Set the column data type
                //.HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax

                //modelBuilder.Entity<Post>()
                //.Property(e => e.CreatedDate)
                //.HasColumnName("CreatedDate")  // Optional: Set the column name
                //.HasColumnType("datetime")     // Optional: Set the column data type
                //.HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax

                //Seed Data
                //modelBuilder.Entity<Blog>()
                //    .HasData(
                //        new Blog() { BlogId = 3, CreatedDate = DateTime.Now, Title = "Quantum" },
                //        new Blog() { BlogId = 2, CreatedDate = DateTime.Now, Title = "Evolution" }
                //    );
                ////Seed Data da pk ler manuel olaraq verilmelidir mutleq
                //modelBuilder.Entity<Post>()
                //    .HasData(
                //        new Post() { PostId = 8, BlogId = 2,Content = "Islam and evolution", CreatedDate = DateTime.Now },
                //        new Post() { PostId = 2, BlogId = 1,Content = "Schrodinger's cat", CreatedDate = DateTime.Now }
                //    );
                //her hansi pk i deyismek istesek eger evvelki migrationlar qalibsa onlara baxacq ve cascade ederek ona uygun diger tabledaki datalari da silecek, ama eger butun migrationlari silmisikse, onda ise xeta verecek, cunki neye uygun sileceyini bilmeyecek

                //seed datalar ancaq migration zamani lazim olur


                //------------------------------------------------------
                //many to many
                //modelBuilder.Entity<BookAuthor>()
                //.HasKey(ba => new { ba.BookId, ba.AuthorId });

                //modelBuilder.Entity<BookAuthor>()
                //.Property(e => e.CreatedDate)
                //.HasColumnName("CreatedDate")  // Optional: Set the column name
                //.HasColumnType("datetime")     // Optional: Set the column data type
                //.HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


                //modelBuilder.Entity<BookAuthor>()
                //    .HasOne(ba => ba.Book)
                //    .WithMany(b => b.BookAuthors)
                //    .HasForeignKey(ba => ba.BookId)
                //    .OnDelete(DeleteBehavior.Cascade);

                //modelBuilder.Entity<Book>()
                //.Property(e => e.CreatedDate)
                //.HasColumnName("CreatedDate")  // Optional: Set the column name
                //.HasColumnType("datetime")     // Optional: Set the column data type
                //.HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax


                //modelBuilder.Entity<BookAuthor>()
                //    .HasOne(ba => ba.Author)
                //    .WithMany(a => a.BookAuthors)
                //    .HasForeignKey(ba => ba.AuthorId)
                //    .OnDelete(DeleteBehavior.Cascade);

                //modelBuilder.Entity<Author>()
                //.Property(e => e.CreatedDate)
                //.HasColumnName("CreatedDate")  // Optional: Set the column name
                //.HasColumnType("datetime")     // Optional: Set the column data type
                //.HasDefaultValueSql("GETDATE()");  // Optional: Set a default value using SQL Server syntax

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
                //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


                //GetEntityTypes - cox da aktiv ist. etmesek de, bilmek faydalidi
                //var entities = modelBuilder.Model.GetEntityTypes();
                //foreach (var entity in entities)
                //{
                //    Console.WriteLine(entity.Name);
                //}

                //==================================
                //discriminator
                //modelBuilder.Entity<Person>()
                //    .HasDiscriminator<int>("ayirici")//eger ada gore yox, int deyere gore ayrimaq isteyirsense
                //    .HasValue<Person>(1)
                //    .HasValue<Employee>(2)
                //    .HasValue<Customer>(3)
                //    .HasValue<Technician>(4);
                //yaxud string edib, ferqli ad vere bilirik ve s.

                //--------
                //TPT
                //ToTable ile konf. edilir

                //modelBuilder.Entity<Person>().ToTable(nameof(Persons));
                //modelBuilder.Entity<Employee>().ToTable(nameof(Employees));
                //modelBuilder.Entity<Customer>().ToTable(nameof(Customers));
                //modelBuilder.Entity<Technician>().ToTable(nameof(Technicians));

                //modelBuilder.Entity<Person>().UseTphMappingStrategy();


                //TPC
                //UseTpcMappingStrategy - bu funksiya ile tph kimi de konf. etmek mumkundur
                //kmodelBuilder.Entity<Person>().UseTpcMappingStrategy();

                //============================
                //PK

                //Alternate Key
                //modelBuilder.Entity<Person>()
                //    .HasAlternateKey(b => b.Name);

                //modelBuilder.Entity<Person>()
                //    .HasAlternateKey(b => new {b.Name,b.Surname})
                //    .HasName("Composite_Unique_Key");

                //Foreign Key - ya fluent api, ya da data annotation ile
                //modelBuilder.Entity<Blog>()
                //    .HasMany(b=>b.Posts)
                //    .WithOne(b=>b.Blog)
                //    .HasForeignKey(p=>p.BlogId);

                //Composite Foreign Key

                //Shadow Properties - eslinde olmayana column uzerinden baglayir

                //HasConstraintName
                //modelBuilder.Entity<Blog>()
                //    .Property<int>("BlogForeignKeydId");

                //modelBuilder.Entity<Blog>()
                //    .HasMany(b => b.Posts)
                //    .WithOne(b => b.Blog)
                //    //.HasForeignKey(p => new { p.BlogId, p.Content });
                //    .HasForeignKey("BlogForeignKeyId")
                //    .HasConstraintName("exampleforeignkey");

                //Unique Key Constraint
                //modelBuilder.Entity<Blog>()
                //    .HasIndex(b => b.CreatedDate)
                //    .IsUnique();

                //ya da Alternate Key ile
                //modelBuilder.Entity<Blog>()
                //    .HasAlternateKey(b => b.CreatedDate);

                //Check Constraint - custom constraints (eger ozumuz sert yaratmaq isteyirikse)
                //Meselen, eger A ve B columnlarimiz varsa ve ancaq A Bden boyukse deyer qebul etsin desek
                //onda check constraint yaradiqiriq

                //modelBuilder.Entity<Blog>()
                //    .HasCheckConstraint("a_b_check_constraint", "[A] > [B]");

                //====================================

                //indexing

                //modelBuilder.Entity<Employee>()
                //    .HasIndex(b => b.Department);
                //indeksleme odur ki, bu column uzerinden yalniz sorgularda daha suretli performance var

                //composite indexing

                //modelBuilder.Entity<Person>()
                //   .HasIndex(p => new { p.Name, p.Surname })
                //   .IsUnique();

                //HasFiltert
                //modelBuilder.Entity<Employee>()
                //    .HasIndex(e => e.Name)
                //    .HasFilter("[NAME] IS NOT NULL");//boyuk datalarda performansda ferq edir

                //Included Columns
                //modelBuilder.Entity<Employee>()
                //    .HasIndex(e => e.Name)
                //    .IncludeProperties(e=>e.Department);

                //==========================
                //SEQUENCE - avtomatik artan deyerler yaradir
                //Sequence - identityden daha suretli ve performancslidi, cunki diskden yox, ramdan alir
                //Sequence - db obyektidir, identity ise table ozelliyi
                //Sequence - herhansi table a bagli deyildir

                //modelBuilder.HasSequence("Ec_Sequence")
                //    .StartsAt(100)
                //    .IncrementsBy(5);

                //modelBuilder.Entity<Blog>()
                //    .Property(b => b.BlogId)
                //    .HasDefaultValueSql("NEXT VALUE FOR Ec_Sequence");
                //modelBuilder.Entity<Customer>()
                //    .Property(c => c.Id)
                //    .HasDefaultValueSql("NEXT VALUE FOR Ec_Sequence");


                //=======================================
                //=======================================
                //Loading Datas


                //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                //modelBuilder.Entity<Employee>()
                //    .Navigation(e => e.Region)
                //    .AutoInclude();

                //=====================================
                modelBuilder.Entity<Person>()
                    .HasKey(p => p.PersonId);

                modelBuilder.Entity<Order>()
                    .HasKey(o => o.Id);
                modelBuilder.Entity<Order>()
                    .HasOne(o => o.Person)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(o => o.PersonId);

                modelBuilder.Entity<Photo>()
                    .HasKey(ph => ph.Id);
                modelBuilder.Entity<Photo>()
                    .HasOne(ph => ph.Person)
                    .WithOne(p => p.Photo)
                    .HasForeignKey<Photo>(ph=>ph.PersonId);

                //=========================view
                //modelBuilder.Entity<PersonOrder>()
                //    .ToView("vm_PersonOrders")
                //    .HasNoKey();

                //=========================store procedure
                modelBuilder.Entity<PersonOrder>()
                    .HasNoKey();

                //Scalar
                modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(AppDbContext.GetPersonTotalOrderPrice), new[] { typeof(int) }))
                    .HasName("GetPersonTotalOrderPrice");

                modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(AppDbContext.BestSellingStaff), new[] { typeof(int) }))
                    .HasName("BestSellingStaff");
                modelBuilder.Entity<BestSellingStaff>()
                    .HasNoKey();

                //KET
                modelBuilder.Entity<PersonOrderCount>()
                    .HasNoKey()
                    .ToView("vw_PersonOrderCount");

                base.OnModelCreating(modelBuilder);

            }

            //Scalar entity
            public double GetPersonTotalOrderPrice(int personId)
            {
                throw new Exception();
            }

            //Inline entity
            public IQueryable<BestSellingStaff> BestSellingStaff(int totalOrderPrice = 0)
                => FromExpression(()=>BestSellingStaff(totalOrderPrice));


            StreamWriter _log = new("logs.txt",append: true);
            protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder
                    //.UseLazyLoadingProxies()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EfCoreCustomizingConfigurations;Trusted_Connection=True;");
                //optionsBuilder.UseLazyLoadingProxies();

                //logging - default olaraq debug daxil ondan ustu loglayir
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Warning)//warningin uzerindekini loglayir,bize esas xeta lazimdir, sorgu neticesi yox
                    .EnableSensitiveDataLogging()//enabling sesitive data
                    .EnableDetailedErrors();//enabling detailed errors

                //optionsBuilder.LogTo(message => Debug.WriteLine(message));
                //optionsBuilder.LogTo(message =>_log.WriteLine(message));
                //optionsBuilder.LogTo(async message => await _log.WriteLineAsync(message))
                //    .EnableSensitiveDataLogging()
                //    .EnableDetailedErrors();

            }

            public override void Dispose()
            {
                base.Dispose();
                _log.Dispose();
            }

            public override async ValueTask DisposeAsync()
            {
                await _log.DisposeAsync();
                await base.DisposeAsync(); 
            }

            //public DbSet<Person> Persons { get; set; }
            //public DbSet<Address> Addresses { get; set; }
            //public DbSet<Blog> Blogs { get; set; }
            //public DbSet<Post> Posts { get; set; }
            //public DbSet<Book> Books { get; set; }
            //public DbSet<Author> Authors { get; set; }
            //public DbSet<BookAuthor> BookAuthors { get; set; }
            //public DbSet<Example> Examples { get; set; }
            //public DbSet<A> As { get; set; }
            //public DbSet<B> Bs { get; set; }
            //public DbSet<MyEntity> MyEntities { get; set; }
            //public DbSet<Person> Persons { get; set; }
            //public DbSet<Employee> Employees { get; set; }
            //public DbSet<Customer> Customers { get; set; }
            //public DbSet<Technician> Technicians { get; set; }


            //=========================================
            //=========================================
            //Loading Datas

            //public DbSet<Person> Persons { get; set; }
            //public DbSet<Employee> Employees { get; set; }
            //public DbSet<Order> Orders { get; set; }
            //public DbSet<Region> Regions { get; set; }

            //===============================
            public DbSet<Person> Persons { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Photo> Photos { get; set; }
            public DbSet<PersonOrderCount> PersonOrderCounts { get; set; }

            //======================= View
            public DbSet<PersonOrder> PersonOrders { get; set; }


        }

    }

    //public static class LazyLoadingExtension
    //{
    //    public static TRelated Load<TRelated>(this Action<object, string> loader,
    //        object entity, ref TRelated navigation,
    //        [CallerMemberName] string navigationName = null)
    //    {
    //        loader.Invoke(entity, navigationName);
    //        return navigation;
    //    }
    //}



}







