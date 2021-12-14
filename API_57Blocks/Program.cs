using API_57Blocks;
using API_57Blocks.Authorization;
using API_57Blocks.Helpers;
using API_57Blocks.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<APIContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("database"));
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

// configure strongly typed settings objects
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISongService, SongService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
