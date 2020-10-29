namespace CipScrapingBot.Configuration.Resilience
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Flurl.Http.Configuration;

    public class PollyHttpClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new PolicyHandler {InnerHandler = base.CreateMessageHandler()};
        }
    }

    public class PolicyHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return FlurExtensions.PolicyStrategy.ExecuteAsync(ct => base.SendAsync(request, ct), cancellationToken);
        }
    }
}