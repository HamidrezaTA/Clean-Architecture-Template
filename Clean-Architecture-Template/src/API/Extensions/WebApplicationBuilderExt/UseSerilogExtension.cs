using Serilog;
using Serilog.Formatting.Json;

namespace API.Extensions.WebApplicationBuilderExt
{
    public static class UseSerilogExtension
    {
        public static void UseCustomSerilog(this WebApplicationBuilder builder)
        {
            var logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo
                                             .Console(new JsonFormatter());
            if (builder.Environment.IsProduction())
                logger.MinimumLevel.Information();
            else
                logger.MinimumLevel.Debug();

            var _serilogLogger = logger.CreateBootstrapLogger();

            builder.Host.UseSerilog(_serilogLogger);
        }
    }
}