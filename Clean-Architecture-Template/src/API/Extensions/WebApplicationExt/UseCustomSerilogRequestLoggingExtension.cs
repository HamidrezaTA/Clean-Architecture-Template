namespace API.Extensions.WebApplicationExt;

using Serilog;

public static class UseCustomSerilogRequestLoggingExtension
{
    public static void UseCustomSerilogRequestLogging(this WebApplication app)
    {
        app.UseSerilogRequestLogging();
    }
}
