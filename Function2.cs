using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace Azure_RestAPI
{
    public static class Function2
    {
        [FunctionName("Function2")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [SignalR(HubName = "broadcast")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<Class2>(requestBody);
            var objectdata = new S();
            objectdata = new S()
            {
                site_id = input.site_id,
                device_id = input.device_id,
                alarm = input.alarm,
                Trouble_count = input.Trouble_count,
                Description = input.Description,
                Maintainence_alert = input.Maintainence_alert,
                RAM_Usage = input.RAM_Usage

            };
            log.LogInformation($"C# IoT Hub trigger function processed a message: {JsonConvert.SerializeObject(objectdata)}");
            await signalRMessages.AddAsync(new SignalRMessage()
            {
                Target = "notify",
                Arguments = new[] { JsonConvert.SerializeObject(objectdata) }
            });
            /*log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
            */
            return new OkResult();
        }
    }
}
