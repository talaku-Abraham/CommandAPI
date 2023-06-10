using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);


//register services to enable the use of controllers
builder.Services.AddControllers();

//DI // we attached the interface with its implementation
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandNewRepo>();



var myConBuilder = new MySqlConnectionStringBuilder();
myConBuilder.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
myConBuilder.UserID = builder.Configuration["User ID"];
myConBuilder.Password = builder.Configuration["Password"];

// var _config = builder.Configuration.GetConnectionString("DefaultConnection");


//register our dbcontext to the configurationservice method& pass the connectionString via the configuration api
 builder.Services.AddDbContext<CommandContext>(options =>
{        options.UseMySql(myConBuilder.ConnectionString,new MySqlServerVersion(new Version(8, 0, 33)));
});

// app.MapGet("/", () => "Hello World!");
//make use of the controller services // mapControllers to our end points
var app = builder.Build();
app.MapControllers();



app.Run();
