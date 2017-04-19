using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;

namespace TestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var isDebug = Debugger.IsAttached || ((IList<string>)args).Contains("--debug");
            string contentRootPath;

            if (isDebug)
                contentRootPath = Directory.GetCurrentDirectory();
            else
            {
                var exePath = Process.GetCurrentProcess().MainModule.FileName;
                contentRootPath = Path.GetDirectoryName(exePath);
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(contentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .Build();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseConfiguration(config)
                .UseContentRoot(contentRootPath)
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            if (isDebug)
            {
                host.Run();
            }
            else
            {
                host.RunAsService();
            }
        }
    }
}
