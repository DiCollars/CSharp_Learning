using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Repositories.User;
using UserService.Services;

using LocalUserService = UserService.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<UserDbContext>(
                        optionsBuilder => optionsBuilder.UseNpgsql(
                                connectionString,
                                options => options.EnableRetryOnFailure(
                                    maxRetryCount: 3,
                                    maxRetryDelay: TimeSpan.FromMilliseconds(100),
                                    errorCodesToAdd: null))
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
                        ServiceLifetime.Transient);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, LocalUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
