using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using Azure_RestAPI;

namespace FunctionApp1
{
    public static class DeleteSite
    {
        [FunctionName("DeleteSite")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "DeleteSite/{id}")] HttpRequest req,
            ILogger log, string id)
        {
            try
            {
                MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");
                var database = client.GetDatabase("Dlocation");
                var collection = database.GetCollection<SiteLocation>("Devices");
                await collection.DeleteOneAsync(sit => sit.Id == id);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult("Error refreshing demo - " + e.Message);
            }
            return (ActionResult)new OkObjectResult("Refreshed site database");
        }
    }
}