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
    public static class UpdateSite
    {
        [FunctionName("UpdateSite")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "UpdateSite/{id}")] HttpRequest req,
            ILogger log,string id)
        {
            try
            {
                MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");

                var database = client.GetDatabase("Dlocation");
                var collection = database.GetCollection<SiteLocation>("Devices");
                var quizUpdateFilter = Builders<SiteLocation>.Filter.Eq("Id", id);

                var update = Builders<SiteLocation>.Update.Set("LocationName", "Sunshine Hospitals");

                var update1 = Builders<SiteLocation>.Update.Set("Location", "Bombay");
                await collection.UpdateOneAsync(quizUpdateFilter, update);
                await collection.UpdateOneAsync(quizUpdateFilter, update1);

            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Error refreshing demo - " + e.Message);

            }
            return (ActionResult)new OkObjectResult("Refreshed site database");
        }
    }
}
