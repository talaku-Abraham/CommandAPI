using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//register services to enable the use of controllers
builder.Services.AddControllers();

//DI // we attached the interface with its implementation
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandNewRepo>();


//making automapper available through dependency injection
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var myConBuilder = new MySqlConnectionStringBuilder();
myConBuilder.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
myConBuilder.UserID = builder.Configuration["User ID"];
myConBuilder.Password = builder.Configuration["Password"];

// var _config = builder.Configuration.GetConnectionString("DefaultConnection");


//register our dbcontext to the configurationservice method& pass the connectionString via the configuration api
 builder.Services.AddDbContext<CommandContext>(options =>
{        options.UseMySql(myConBuilder.ConnectionString,new MySqlServerVersion(new Version(8, 0, 33)));
});


//for patch request 
builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
 s.SerializerSettings.ContractResolver = new
 CamelCasePropertyNamesContractResolver();
});

var app = builder.Build();
//make use of the controller services // mapControllers to our end points

app.MapControllers();

// builder.Services.AddCors(c=>{
//     c.AddPolicy("AllowOrigin", options=>options.AllowAnyOrigin());
// });
// app.UseCors(x=>x.AllowAnyOrigin());




app.Run();
