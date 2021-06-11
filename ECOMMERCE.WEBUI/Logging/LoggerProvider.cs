using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace ECOMMERCE.WEBUI.Logging
{
    public class LoggerProvider : ILoggerProvider
    {
        public IHostingEnvironment _hostingEnvironment;
        public LoggerProvider(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new Logger(_hostingEnvironment);
        }

        public void Dispose() { 
            throw new NotImplementedException(); 
        }
    }
}
