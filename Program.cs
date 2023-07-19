using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApplication2.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region configure core
builder.Services.AddCors(options =>
{
    options.AddPolicy("Custompolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
}
    );
#endregion
#region configure database
var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options=> options.UseSqlServer(ConnectionString));
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Custompolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
