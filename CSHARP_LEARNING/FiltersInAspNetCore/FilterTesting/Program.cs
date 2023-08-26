using FilterTesting.Attributes;
using FilterTesting.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<KeyApplierActionFilter>();
    //options.Filters.Add<KeyCheckerAsyncActionFilter>();
    options.Filters.Add<GlobalActionFilter>();

    options.Filters.Add<AuthFilterOrder>();
    options.Filters.Add<ResourceFilterOreder>();
    options.Filters.Add<ActionFilterOrder>();
    options.Filters.Add<ExceptionFilterOrder>();
    options.Filters.Add<ResultFilterOrder>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen();

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
