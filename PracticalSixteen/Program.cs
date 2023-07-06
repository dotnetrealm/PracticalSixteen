using PracticalSixteen.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

//Custom middleware for request logging
app.UseRequestLoggingMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
