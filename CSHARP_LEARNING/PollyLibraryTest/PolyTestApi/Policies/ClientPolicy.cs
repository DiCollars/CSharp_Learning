using Polly;
using Polly.Retry;

namespace PolyTestApi.Policies
{
    public class ClientPolicy
    {
        public AsyncRetryPolicy<HttpResponseMessage> ImmediateHttpRetry { get; }

        public AsyncRetryPolicy<HttpResponseMessage> LinearHttpRetry { get; }

        public AsyncRetryPolicy<HttpResponseMessage> ExponentialHttpRetry { get; }

        public ClientPolicy()
        {
            ImmediateHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode).RetryAsync(6);

            LinearHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
                .WaitAndRetryAsync(6, retrAttmpt => TimeSpan.FromSeconds(2));

            ExponentialHttpRetry = Policy.HandleResult<HttpResponseMessage>(
                res => !res.IsSuccessStatusCode)
                .WaitAndRetryAsync(3, retrAttmpt => TimeSpan.FromSeconds(Math.Pow(2, retrAttmpt)));
        }
    }
}
