﻿using Serilog.Configuration;
using Serilog;

namespace Challenge.Sinks
{
    public static class CustomSinkExtensions
    {
        public static LoggerConfiguration CustomSink(this LoggerSinkConfiguration loggerConfiguration)
        {
            return loggerConfiguration.Sink(new CustomSink());
        }
    }
}