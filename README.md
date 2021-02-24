# BeautyCenter
BeautyCenter


Проект по предметот Бази на податоци: Beauty Center

Изработиле:

  Анастасија Тренчовска 172001,
  Вања Тошевска 173064

Проектот Beauty Center е веб апликација, изработена во рамката ASP.NET Core верзија 3.1. За изработка на back-end користевме C#, додека за front-end користевме HTML, CSS и bootstrap.

За поврзување на базата се користи конекциски стринг, со потребните информации. Во прилог го доставуваме и source кодот.
Со цел да ја стартувате апликацијата на друг уред најпрво треба да се инсталира најновата верзија на Visual Studio, работна околина на Microsoft. Visual Studio ни овозможува работа во ASP.NET Core рамката, користејќи ја MVC технологијата, во што беше и изработен овој проект. По отварањето на проектот, кој го праќаме во прилог на овој zip фолдер, во делот Tools>NuGet Package> Manager> Manage NuGet Packages for Solution се инсталираат следните поврзувања:
- Npgsql (.NET data provider for PostgresSQL)
- Npgsql.EntityFrameworkCore.PostgreSQL
- Npgsql.EntityFramework.PostgreSQL.Design
- Microsoft.EntiryFrameworkCore.Tools
Дополнително во Package Manager Console се инсталира dotnet tool install --global dotnet-ef.
По инсталацијата, во конзолата се внесува стрингот за конекција со базата. Во нашиот случај:
dotnet-ef dbcontext scaffold "Host=localhost; Database=db_201920z_va_prj_beauty_centar; Username=db_201920z_va_prj_beauty_centar_owner; Password=beauty_centar; Port=9999" Npgsql.EntityFrameworkCore.PostgreSQL --project BeautyCenter --output-dir Models --schema project.

По успешна конекција, веб апликацијата може да се стартува на localhost. При стартувањето се појавува почетната страница. Во делот Регистрација може да регистреирате нов клиент, додека во делот Логин може да најавите некој од корисниците од базата, пример:

Клиент:
Email: zorka@yahoo.com
Лозинка: зорезорица

Вработен:
Email: valerijaa@icloud.com
Лозинка: valeri1998

Менаџер:
Email: mia@google.com
Лозинка: mia123

Директор:
Email: magiM@gmail.com
Лозинка: magi12

По најавувањето, во зависност од улогата на корисникот се прикажуваат различни функционалности.  Клиентот има можност да направи преглед на салоните и услугите во истите. Секоја услуга може да ја додаде во листата на Мои омилени услуги. Исто така, може да направи и преглед на курсевите и да се пријави на некој од нив.
Директорот како корисник може да додава нов курс со внесување на неговото име и цена. Истиот го внесува во салонот во кој е вработен, односно директор.
