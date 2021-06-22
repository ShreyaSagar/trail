using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Azure_RestAPI
{
    public static class Site_Device_
    {
        [FunctionName("Site_Device_")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "Site_Device/{id}")] HttpRequest req,
            ILogger log ,string id)
        {
            IActionResult returnValue = null;
            MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("Dlocation");
            var collection = database.GetCollection<Site_Device_Data>("DeviceDataAtSite");
            
            var result = collection.Find(sit => sit.site_id == id).ToList();

            /*
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<MultiDeviceData>(requestBody);
            */
            /* var result = collection.Aggregate().Group("{'_id':'$site_id'}").ToList();
             * */
            if (result == null)
            {
                log.LogInformation($"There are no albums in the collection");
                returnValue = new NotFoundResult();
            }
            else
            {
                returnValue = new OkObjectResult(result);
            }
            return returnValue;
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
        }
    }
}
