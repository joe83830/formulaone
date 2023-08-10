using FormulaOne.Data;
using FormulaOne.Data.DTOs;
using FormulaOne.Data.Models;
using FormulaOne.Utils.Filtering;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
    builder =>
        builder.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions => { swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP .NET React", Version = "v1" }); });
//builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapGet("/drivers", async (AppDBContext db, HttpContext context) =>
{
    IQueryable<Driver> query = db.Drivers;
    var filter = context.Request.Query["filter"].FirstOrDefault();
    Console.WriteLine("OUTSIDE IF");
    Console.WriteLine(filter);

    if (!string.IsNullOrEmpty(filter))
    {
        try
        {
            var filterObj = JsonConvert.DeserializeObject<ConsolidatedFilter>(filter);
            Console.WriteLine("JOE Filter incoming:");
            Console.WriteLine(filterObj);
            if (filterObj.Forename != null)
            {
                query = query.ApplyTextFilters(filterObj.Forename, driver => driver.Forename);
            }
            if (filterObj.Surname != null)
            {
                query = query.ApplyTextFilters(filterObj.Surname, driver => driver.Surname);
            }
            if (filterObj.Nationality != null)
            {
                query = query.ApplyTextFilters(filterObj.Nationality, driver => driver.Nationality);
            }
            if (filterObj.Code != null)
            {
                query = query.ApplyTextFilters(filterObj.Code, driver => driver.Code);
            }
            if (filterObj.Dob != null)
            {
                query = query.ApplyDateFilters(filterObj.Dob);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
        }

    }

    Console.WriteLine("Joe constructed LINQ query");
    Console.WriteLine(query.ToString());
    var drivers = await query.ToListAsync();
    Console.WriteLine("Joe Drivers");
    Console.WriteLine(drivers);
;    return drivers.Select(d => new DriverDTO
    {
        driverRef = d.DriverRef,
        number = d.Number,
        code = d.Code,
        forename = d.Forename,
        surname = d.Surname,
        dob = d.Dob,
        nationality = d.Nationality
    }).ToList();
});
// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP .NET React";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API Serving a Very Simple Post Model.");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost3000");

app.Run();
