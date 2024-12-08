using Booking.Application;
using Booking.DAL;
using Booking.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.SwaggerDocumentationGenerat();
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterDataBase(builder.Configuration);
builder.Services.RegisterService();
builder.Services.RegisterRepository();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.MapDefaultControllerRoute();

app.UseSwaggerWithUi();

app.Run();
