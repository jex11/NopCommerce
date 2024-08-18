using AutoMapper;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Nop.Web.Areas.Admin.Infrastructure
{
    public class AutoMapperStartupTask : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public AutoMapperStartupTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Create a scope to get services from the DI container
            using var scope = _serviceProvider.CreateScope();
            var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();

            //// Optional: Validate the AutoMapper configuration
            //var mapperConfiguration = scope.ServiceProvider.GetRequiredService<MapperConfiguration>();
            //mapperConfiguration.AssertConfigurationIsValid();

            //AutoMapper successfully initialized
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
