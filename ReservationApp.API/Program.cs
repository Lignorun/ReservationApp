using Microsoft.EntityFrameworkCore;
using ReservationApp.DAL.Models;

var builder = WebApplication.CreateBuilder(args);


// CORS configuration 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        // On production, be more restrict than here
        //policy.WithOrigins("http://localhost:5000") // Add more domin here
        policy.AllowAnyOrigin()
              .AllowAnyHeader()  
              .AllowAnyMethod(); 
    });
});


// Retrieves the database connection password from the environment variable, allowing the password to be protected 
// and easily configured in any environment where the code runs
string? dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

// The same for the Id of the server. 
string? dbId = Environment.GetEnvironmentVariable("DB_ID");

// The connection string is set at appsettings.json
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString == null)
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
}

if (dbPassword == null)
{
    throw new InvalidOperationException("DB_PASSWORD environment variable not set.");
}

if (dbId == null)
{
    throw new InvalidOperationException("DB_Id environment variable not set.");
}


connectionString += $";User Id={dbId};Password={dbPassword}";


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); 


builder.Services.AddOpenApi();

var app = builder.Build();


// For the Swagger
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Redirect any error to an error page
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Redirects errors to a specific page
    app.UseHsts(); // Enforces HTTPS security policy
}

app.UseHttpsRedirection();

// Restrict the origin of all the requests to the API (CORS)
app.UseCors("AllowSpecificOrigins");

app.Run();


