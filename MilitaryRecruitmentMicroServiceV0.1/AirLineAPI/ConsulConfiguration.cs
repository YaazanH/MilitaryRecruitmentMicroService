using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Threading;
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Consul;

namespace AirLineAPI
{
    public class ConsulConfiguration
    {
        public string Url { get; set; }
    }

    public class ServiceConfiguration
    {
        public string Url { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }

    public class ConsulRegisterService : IHostedService
    {
        private IConsulClient _consulClient;
        private ConsulConfiguration _consulConfiguration;
        private ServiceConfiguration _serviceConfiguration;
        private ILogger<ConsulRegisterService> _logger;

        public ConsulRegisterService(IConsulClient consulClient,
            IOptions<ServiceConfiguration> serviceConfiguration,
            IOptions<ConsulConfiguration> consulConfiguration,
            ILogger<ConsulRegisterService> logger)
        {
            _consulClient = consulClient;
            _consulConfiguration = consulConfiguration.Value;
            _serviceConfiguration = serviceConfiguration.Value;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var serviceUri = new Uri(_serviceConfiguration.Url);

            var ServiceCheck = new AgentServiceCheck()
            {
                HTTPS = $"https://{serviceUri.Host}:{serviceUri.Port}/AirLine/GetIsAWorker?id=2",
                Notes = $"https://{serviceUri.Host}:{serviceUri.Port}/AirLine/GetIsAWorker?id=2",
                Timeout = TimeSpan.FromSeconds(3),
                Interval = TimeSpan.FromSeconds(10)
            };
            

            var serviceRegistration = new AgentServiceRegistration()
            {
                Address = serviceUri.Host,
                Name = _serviceConfiguration.ServiceName,
                Port = serviceUri.Port,
                ID = _serviceConfiguration.ServiceId,
                Tags = new[] { $"http://{serviceUri.Host}:{serviceUri.Port}/AirLine/GetIsAWorker?id=2" },
                Checks = new[] { ServiceCheck }
                /*new AgentCheckRegistration()
                {
                    HTTP = $"http://{serviceUri.Host}:{serviceUri.Port}/AirLine/CheckHealth",
                    Notes = "Checks /health/status on localhost",
                    Timeout = TimeSpan.FromSeconds(3),
                    Interval = TimeSpan.FromSeconds(10)
                }*/
            };

            await _consulClient.Agent.ServiceDeregister(_serviceConfiguration.ServiceId, cancellationToken);
            await _consulClient.Agent.ServiceRegister(serviceRegistration, cancellationToken);

        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _consulClient.Agent.ServiceDeregister(_serviceConfiguration.ServiceId, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when trying to de-register", ex);
            }
        }
    }
}