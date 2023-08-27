using System.Text;
using DotNetCore.CAP;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.MessageBus.CAP.Extensions.CapOptionsExt
{
    public static class FailedThresholdCallbackExt
    {
        public static void AddFailedThresholdCallbackExt(this CapOptions options)
        {
            options.FailedThresholdCallback = (info) =>
             {
                 var _logger = info.ServiceProvider.GetService<ILogger>();

                 _logger.LogError("Cap failed to consume");

                 foreach (var header in info.Message.Headers)
                 {
                     _logger.LogError(header.Key + " : " + header.Value);
                 }

                 string encodedData = info.Message.Value.ToString();
                 string base64Part = encodedData.Substring(encodedData.IndexOf(',') + 1);
                 byte[] decodedBytes = Convert.FromBase64String(base64Part);
                 string decodedString = Encoding.UTF8.GetString(decodedBytes);

                 _logger.LogError("body : " + decodedString);

             };
        }
    }
}