using Application;
using Application.DataAccess;

var AllowSpecificOrigins = "_allowSpecificOrigins";

ConnectionConfig.InitializeConnection(DatabaseType.Sql, "filedropper");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(AllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();



app.Run();
