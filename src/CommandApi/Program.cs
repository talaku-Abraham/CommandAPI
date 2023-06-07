var builder = WebApplication.CreateBuilder(args);


//register services to enable the use of controllers
builder.Services.AddControllers();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
//make use of the controller services // mapControllers to our end points
app.MapControllers();

app.Run();
