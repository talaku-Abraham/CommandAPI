using CommandApi.Data;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);


//register services to enable the use of controllers
builder.Services.AddControllers();

//DI // we attached the interface with its implementation
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandNewRepo>();



ConfigurationManager config = builder.Configuration;


// var mysqlConBuilder = new MySqlConnectionStringBuilder();
// mysqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");



// builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));


//  builder.Services.AddDbContext<CommandContext>(options =>
// {        options.UseMySql(mysqlConBuilder.ConnectionString,new MySqlServerVersion(new Version(8, 0, 33)));
// });


var _config = builder.Configuration.GetConnectionString("DefaultConnection");
// var connection =_config.GetConnectionString("DefaultConnection");
 builder.Services.AddDbContext<CommandContext>(options =>
{        options.UseMySql(_config,new MySqlServerVersion(new Version(8, 0, 33)));
});

// app.MapGet("/", () => "Hello World!");
//make use of the controller services // mapControllers to our end points
var app = builder.Build();
app.MapControllers();



app.Run();
