using Common;
using CrypticWizard.RandomWordGenerator;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService;
using static CrypticWizard.RandomWordGenerator.WordGenerator;

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

app.MapGet("/get-orders", async ([FromQuery] int? skip, [FromQuery] int? take) =>
{
    using (OrderDbContext db = new OrderDbContext())
    {
        return await db.Orders.Skip(skip ?? 0).Take(take ?? 100).ToListAsync();
    }
})
.WithOpenApi();

app.MapGet("/get-order-info", async ([FromQuery] Guid orderId) =>
{
    using (OrderDbContext db = new OrderDbContext())
    {
        return await db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
    }
})
.WithOpenApi();

app.MapPost("/update-order-info", async ([FromQuery] Guid orderId,
    [FromQuery] OrderStatus orderStatus,
    [FromQuery] Guid userId) =>
{
    using (OrderDbContext db = new OrderDbContext())
    {
        var order = await db.Orders.FirstOrDefaultAsync(o => o.Id == orderId);

        if (OrderStateMachine(order.Status, orderStatus))
        {
            order.Status = orderStatus;
            order.UserId = userId;
            db.Orders.Update(order);
            await db.SaveChangesAsync();

            return Results.Ok();
        }
        else
        {
            return Results.BadRequest(orderId);
        }
    }
})
.WithOpenApi();

await InitDbData();

app.Run();

async Task InitDbData()
{
    using (OrderDbContext db = new OrderDbContext())
    {
        if (db.Orders.Any())
        {
            return;
        }

        WordGenerator myWordGenerator = new WordGenerator();
        for (int i = 0; i <= 1000; i++)
        {
            var word = myWordGenerator.GetWord(PartOfSpeech.noun);

            await db.Orders.AddAsync(new OrderEntity
            {
                Count = new Random().Next(1, 5),
                Id = Guid.NewGuid(),
                Name = myWordGenerator.GetWord(PartOfSpeech.noun),
                Status = OrderStatus.NotOrdered,
                UserId = null,
                Costs = new Random().Next(50, 2000)
            });
        }

        await db.SaveChangesAsync();
    }
}

bool OrderStateMachine(OrderStatus currentStatus, OrderStatus newStatus)
{
    if (currentStatus < newStatus)
    {
        return true;
    }

    return false;
}