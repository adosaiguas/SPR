using Quartz.Impl;
using SPR.Hosts;
using System.Configuration;
using Topshelf;

namespace SPR.Service.ConfigureServcie
{
    internal static class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(config =>
            {
                config.EnableShutdown();
                config.RunAsNetworkService();
                config.SetServiceName(typeof(Program).Namespace);
                config.SetDisplayName(typeof(Program).Namespace);
                config.SetDescription(ConfigurationManager.AppSettings["performanceConfiguration"]);
                config.Service<ISelfHostService>(service =>
                {
                    service.ConstructUsing(s => new SelfHostService(StdSchedulerFactory.GetDefaultScheduler()));
                    service.WhenStarted(s => s.Run());
                    service.WhenShutdown(s => s.ShutDown());
                    service.WhenStopped(s => s.Stop());
                });

            });
        }

    }
}
