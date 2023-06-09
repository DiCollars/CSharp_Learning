using Polly;
using PolyTestApi.Policies;

var builder = WebApplication.CreateBuilder(args);

//Basic
//builder.Services.AddHttpClient("BaseClient")
//    .AddPolicyHandler(request => new ClientPolicy().LinearHttpRetry);

//Const
var retryPolicy = Policy.Handle<HttpRequestException>()
    .OrResult<HttpResponseMessage>(response => response.IsSuccessStatusCode == false)
    .WaitAndRetryAsync(new[]
    {
        TimeSpan.FromSeconds(1),
        TimeSpan.FromSeconds(3),
        TimeSpan.FromSeconds(8)
    });
builder.Services.AddHttpClient("BaseClient")
.AddPolicyHandler(retryPolicy);

builder.Services.AddSingleton<ClientPolicy>(new ClientPolicy());

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

app.MapGet("/get-status-const-client-factory", async (IHttpClientFactory clientFactory, ILogger<Program> logger) =>
{
    var client = clientFactory.CreateClient("BaseClient");
    var result = await client.GetAsync("https://localhost:7085/get-time");

    if (result.IsSuccessStatusCode != true)
    {
        return $"ERROR:{result.StatusCode}";
    }

    return await GetResult(result);
});

app.MapGet("/get-status-immidiate", async (ClientPolicy clientPolicy, ILogger<Program> logger) =>
{
    var client = new HttpClient();
    var count = 1;
    var result = await clientPolicy.ImmediateHttpRetry.ExecuteAsync(async () =>
    {
        var result = await client.GetAsync("https://localhost:7085/get-time");

        logger.LogWarning($"{DateTime.Now} - Try# {count}");
        count++;

        return result;
    });

    if (result.IsSuccessStatusCode != true)
    {
        return $"ERROR:{result.StatusCode}";
    }

    return await GetResult(result);
});

app.MapGet("/get-status-linear", async (ClientPolicy clientPolicy, ILogger<Program> logger) =>
{
    var client = new HttpClient();
    var count = 1;
    var result = await clientPolicy.LinearHttpRetry.ExecuteAsync(async () =>
    {
        var result = await client.GetAsync("https://localhost:7085/get-time");

        logger.LogWarning($"{DateTime.Now} - Try# {count}");
        count++;

        return result;
    });

    if (result.IsSuccessStatusCode != true)
    {
        return $"ERROR:{result.StatusCode}";
    }

    return await GetResult(result);
});

app.MapGet("/get-status-exponential", async (ClientPolicy clientPolicy, ILogger<Program> logger) =>
{
    var client = new HttpClient();
    var count = 1;
    var result = await clientPolicy.ExponentialHttpRetry.ExecuteAsync(async () =>
    {
        var result = await client.GetAsync("https://localhost:7085/get-time");

        logger.LogWarning($"{DateTime.Now} - Try# {count}");
        count++;

        return result;
    });

    if (result.IsSuccessStatusCode != true)
    {
        return $"ERROR:{result.StatusCode}";
    }

    return await GetResult(result);
});

app.Run();

static async Task<string> GetResult(HttpResponseMessage httpResponseMessage)
{
    var stringDate = (await httpResponseMessage.Content.ReadAsStringAsync()).Replace("\"", string.Empty);
    var date = DateTime.Parse(stringDate);
    return $"{Guid.NewGuid()} - {date.TimeOfDay} - {date.Year} - {date.DayOfWeek}";
}