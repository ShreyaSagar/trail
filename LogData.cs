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
using System.Collections.Generic;
using System.Linq;

namespace Azure_RestAPI
{
    public static class LogData
    {
        [FunctionName("LogData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string s = "";
            IActionResult returnValue = null;
            string filePath = @"C:\Users\shreya\Desktop\logs.txt";
            List<String> lines = new List<String>();
            lines = File.ReadAllLines(filePath).ToList();
            foreach (String line in lines)
            {
                s = s + line+ System.Environment.NewLine;
               /* Console.WriteLine(line);*/
            }
           
             /* Console.ReadLine();*/
            log.LogInformation("hiii");
            log.LogInformation(s);
            returnValue = new OkObjectResult(s);
            /*
            IActionResult returnValue = null;
            MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("Dlocation");
            var collection = database.GetCollection<Class3>("SitesId");

            var result = collection.Find(sit =>true).ToList(); 

            /*
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<MultiDeviceData>(requestBody);
            */
            /* var result = collection.Aggregate().Group("{'_id':'$site_id'}").ToList();
             * 
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
            */
            return returnValue;
        }
    }
}
