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
    public static class GetRequiredDocumentById
    {
        [FunctionName("GetRequiredDocumentById")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "GetRequiredDocumentById/{id}")] HttpRequest req,
            ILogger log, string id)
        {
            IActionResult returnValue = null;
            try
            {
                MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");
                var database = client.GetDatabase("Dlocation");
                var collection = database.GetCollection<SiteLocation>("Devices");
                var result = collection.Find(sit => sit.Id == id).FirstOrDefault();
                if (result == null)
                {
                    log.LogWarning("That item doesn't exist!");
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
