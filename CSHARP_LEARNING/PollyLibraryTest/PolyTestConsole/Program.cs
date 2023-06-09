using Polly;

HttpClient _client = new HttpClient();

var pollyContext = new Context("Retry 400");
var policy = Policy
    .Handle<HttpRequestException>(ex => ex.Message.Contains("400"))
    .WaitAndRetryAsync(
        58,
        _ => TimeSpan.FromMilliseconds(500),
        (result, timespan, retryNo, context) =>
        {
            Console.WriteLine($"{context.OperationKey}: Retry number {retryNo} within {timespan.TotalMilliseconds}ms.");
        }
    );

Thread.Sleep(3000);

var errorCode = 400;

try
{
    var response = await policy.ExecuteAsync(async ctx =>
    {
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://localhost:7085/get-time"));
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return response;
    }, pollyContext);

    Console.WriteLine(await response.Content.ReadAsStringAsync());
}
catch (Exception ex)
{
    Console.WriteLine("Retry limit exceeded!");
}