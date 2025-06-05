//w nuget biblioteki:
//Microsoft.Data.SqlClient
//Swashbuckle.AspNetCore.SwaggerGen
//Swashbuckle.AspNetCore.SwaggerUI


using cwiczenia12.Data;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(
    "appsettings.json", 
    optional: false, 
    reloadOnChange: true
);

//builder.Services.AddScoped<IDeliveriesService, DeliveriesService>();

builder.Services.AddDbContext<_2019sbdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAuthorization(); 
builder.Services.AddControllers(); 

builder.Services.AddSwaggerGen(c => 
{
    c.SwaggerDoc("v1", new()
    {
        Title = "cwiczenia12", 
        Version = "v1",
        Description = "cwiczenia12",
        Contact = new()
        {
            Name = "Dariusz",
            Email = "xxxxx@gmail.com",
            Url = new Uri("https://github.com/Dars00n00")
        },
        // License = new()
        // {
        //     
        // }
    });
});

var app = builder.Build(); 

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "cwiczenia12");
    c.DocExpansion(DocExpansion.List);
    c.DefaultModelExpandDepth(0);
    c.DisplayRequestDuration();
    c.EnableFilter();
});


app.UseAuthorization();
app.MapControllers(); 

app.Run();



// aby pobrać conn str należy użyć Iconfiguration
// dot net automatycznie wstrzykuje zależność
// IConfiguration configuration;
// var connStr = configuration.GetConnectionString("nazwa");

// dotnet ef dbcontext scaffold "Name=ConnectionStrings:main" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models --table cwiczenia12_Trip --table cwiczenia12_Client --table cwiczenia12_Country --table cwiczenia12_Client_Trip --table cwiczenia12_Country_Trip --project cwiczenia12/cwiczenia12.csproj