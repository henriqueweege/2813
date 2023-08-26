using DependencyRoomBooking.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.AddRepositories();
builder.Services.AddConverters();
builder.Services.AddDbContext();
builder.Services.AddInfrastructureServices();
builder.Services.AddMediatR();
builder.Services.AddSwagger();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
