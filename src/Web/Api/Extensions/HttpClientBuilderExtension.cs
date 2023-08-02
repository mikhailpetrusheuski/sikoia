using Polly;

namespace Api.Extensions;

public static class HttpClientBuilderExtension
{
    public static IHttpClientBuilder AddRetryPolicy(this IHttpClientBuilder builder)
    {
        return builder.AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(new[]
        {
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(3),
            TimeSpan.FromSeconds(5)
        })).AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
    }
}