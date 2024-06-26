
using LinhaDeMontagem;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LinhaDeMontagemDescricao>();

var app = builder.Build();


app.UseAddChassiMiddleware();
app.UseAddMotorMiddleware();
app.UseAddPortasMiddleware();
app.UseAddPinturaMiddleware();
app.UseAddInternoMiddleware();



app.Run();