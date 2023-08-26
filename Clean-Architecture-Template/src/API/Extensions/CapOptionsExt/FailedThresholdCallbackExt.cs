using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;

namespace API.Extensions.CapOptionsExt
{
    public static class FailedThresholdCallbackExt
    {
        public static void AddFailedThresholdCallbackExt(this CapOptions options)
        {
            options.FailedThresholdCallback = (info) =>
             {

                 // var logger = failed.ServiceProvider.GetService<ILogger<Startup>>();
                 //     logger.LogError($@"A message of type {failed.MessageType} failed after executing {x.FailedRetryCount} several times, 
                 //         requiring manual troubleshooting. Message name: {failed.Message.GetName()}");

                 //TODO: Hamidreza, Fix it
                 //     foreach (var header in info.Message.Headers)
                 //     {
                 //         Log.Error(header.Key + " : " + header.Value);
                 //     }
                 //     string encodedData = info.Message.Value.ToString();

                 //     // Extract the base64-encoded part after the comma
                 //     string base64Part = encodedData.Substring(encodedData.IndexOf(',') + 1);

                 //     // Decode the base64-encoded string to bytes
                 //     byte[] decodedBytes = Convert.FromBase64String(base64Part);

                 //     // Convert the bytes to a UTF-8 encoded string
                 //     string decodedString = Encoding.UTF8.GetString(decodedBytes);

                 //     Log.Error("body : " + decodedString);
                 //     var obj = System.Text.Json.JsonSerializer.Deserialize<PayloadDto>(decodedString);

             };
        }
    }
}