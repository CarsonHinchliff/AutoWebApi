using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoWebApiSample1.HostedService
{
    public class HostedService1 : IHostedService
    {
        private readonly ILogger<HostedService1> _logger = null;
        public HostedService1(ILogger<HostedService1> logger = null)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{this.GetType()} started...");
            WatchDir();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{this.GetType()} stopped...");
            return Task.CompletedTask;
        }

        void WatchDir()
        {
            using (var fsw = new FileSystemWatcher(@"C:\Users\carsonmax\Desktop\"))
            {
                fsw.EnableRaisingEvents = true;
                fsw.IncludeSubdirectories = true;

                fsw.Created += Fsw_Created;
                fsw.Changed += Fsw_Changed;
                fsw.Deleted += Fsw_Deleted;
                fsw.Renamed += Fsw_Renamed;
                fsw.Error += Fsw_Error;

                Console.ReadLine();
            }
        }

        private void Fsw_Error(object sender, ErrorEventArgs e)
        {
            _logger.LogInformation($"{e}");
        }

        private void Fsw_Renamed(object sender, RenamedEventArgs e)
        {
            _logger.LogInformation($"{e.OldFullPath}, {e.FullPath}");
        }

        private void Fsw_Deleted(object sender, FileSystemEventArgs e)
        {
            _logger.LogInformation($"{e.FullPath}, {e.ChangeType}");
        }

        private void Fsw_Created(object sender, FileSystemEventArgs e)
        {
            _logger.LogInformation($"{e.FullPath}, {e.ChangeType}");
        }

        private void Fsw_Changed(object sender, FileSystemEventArgs e)
        {
            _logger.LogInformation($"{e.FullPath}, {e.ChangeType}");
        }
    }
}
