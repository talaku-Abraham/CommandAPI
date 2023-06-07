using CommandApi.Data;

var builder = WebApplication.CreateBuilder(args);


//register services to enable the use of controllers
builder.Services.AddControllers();

//DI // we attached the interface with its implementation
builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
//make use of the controller services // mapControllers to our end points
app.MapControllers();

app.Run();
