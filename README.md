# CoursesEF
Entity Framework example with a Courses Database

# For running the solution
Change your connection in CoursedDAL/ApplicationDbContext.cs:

    optionsBuilder.UseSqlServer(@"Data Source=.,5433;User Id=sa;Password=putyourpassword;Initial Catalog=CoursesDB");

Execute the SQL Server file SQLQuery_1.sql

Finally run the project:

    dotnet run --project CoursesClient/CoursesClient.csproj
