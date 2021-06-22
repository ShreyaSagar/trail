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
    public static class CreateSite
    {
        [FunctionName("CreateSite")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            try
            {
                MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");
                var database = client.GetDatabase("Dlocation");
                var collection = database.GetCollection<SiteLocation>("Devices");
                log.LogInformation("Creating a new todo list item");
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var input = JsonConvert.DeserializeObject<SiteLocation>(requestBody);

                var siteLocation = new SiteLocation() {
                    site_id=input.site_id,
                    Name=input.Name,
                    Location=input.Location,
                    Devices=input.Devices,
                    LastServicedDate=input.LastServicedDate,
                    ServiceDueDate=input.ServiceDueDate,
                    Contact=input.Contact
                    
                };
                await collection.InsertOneAsync(siteLocation);
                return new OkObjectResult(siteLocation);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Error refreshing demo - " + e.Message);
            }

            
        }
    }
}
