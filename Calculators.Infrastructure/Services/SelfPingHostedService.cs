using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Calculators.Infrastructure.Services
{
    public class SelfPingHostedService : BackgroundService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string? _pingUrl;
        private readonly ILogger<SelfPingHostedService> _logger;

        public SelfPingHostedService(
            IConfiguration configuration,
            ILogger<SelfPingHostedService> logger,
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _pingUrl = configuration["SELF_PING_URL"];
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (string.IsNullOrEmpty(_pingUrl))
            {
                _logger.LogWarning("SELF_PING_URL is not configured. Self-ping service will not start.");
                return;
            }

            _logger.LogInformation("Self-ping service started. URL: {PingUrl}", _pingUrl);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var client = _httpClientFactory.CreateClient();
                    var response = await client.GetAsync(_pingUrl, stoppingToken);

                    if (response.IsSuccessStatusCode)
                    {
                        _logger.LogInformation("Self ping successful at {Time}", DateTime.UtcNow);
                    }
                    else
                    {
                        _logger.LogWarning("Self ping failed with status code: {StatusCode}", response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Self ping exception");
                }

                await Task.Delay(TimeSpan.FromMinutes(12), stoppingToken);
            }
        }
    }
}
