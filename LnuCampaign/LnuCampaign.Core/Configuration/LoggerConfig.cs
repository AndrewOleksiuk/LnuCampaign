using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Core;
using Serilog.Sinks;

namespace LnuCampaign.Configuration
{
    public static class LoggerConfig
    {
        public static Logger ConfigureLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
        }
    }
}
