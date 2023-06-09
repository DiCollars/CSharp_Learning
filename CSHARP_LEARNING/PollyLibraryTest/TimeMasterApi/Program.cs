var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();

app.MapGet("/get-time", async (HttpRequest req, ILogger<Program> logger) =>
{
    var val = new Random().Next(1, 8);
    logger.LogWarning($"{DateTime.Now} - Generated value is - {val}");

    if (val == 6) //Imitation of problem
    {
        return Results.Ok(DateTime.Now.ToString());
    }

    return Results.BadRequest();
});

app.Run();