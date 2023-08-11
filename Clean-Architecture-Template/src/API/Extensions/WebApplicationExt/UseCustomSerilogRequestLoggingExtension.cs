using Serilog;

namespace API.Extensions.WebApplicationExt
{
    public static class UseCustomSerilogRequestLoggingExtension
    {
        public static void UseCustomSerilogRequestLogging(this WebApplication app)
        {
            app.UseSerilogRequestLogging();
        }
    }
}