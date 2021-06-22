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

namespace Azure_RestAPI
{
    public static class GetDeviceData
    {
        [FunctionName("GetDeviceData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            IActionResult returnValue = null;
            try
            {
                MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");
                var database = client.GetDatabase("Dlocation");
                var collection = database.GetCollection<Site_Device_Data>("DeviceDataAtSite");
                var result = collection.Find(site => true).ToList();
                // ...
                /*var output = JsonConvert.SerializeObject(result);*/
                if (result == null)
                {
                    log.LogInformation($"There are no albums in the collection");
                    returnValue = new NotFoundResult();
                }
                else
                {
                    returnValue = new OkObjectResult(result);
                }
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Error refreshing demo - " + e.Message);
            }

            return returnValue;
        }
    }
}
