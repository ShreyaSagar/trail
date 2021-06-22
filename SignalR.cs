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
using Newtonsoft.Json.Linq;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Azure_RestAPI
{
    public static class SignalR
    {
        [FunctionName("SignalR")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [SignalR(HubName = "broadcast")] IAsyncCollector<SignalRMessage> signalRMessages,
            ILogger log)
        {
            MongoClient client = new MongoClient("mongodb+srv://user_1:xfTccskbC0ZvmJlA@cluster0.ebtof.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("Dlocation");
            var collection = database.GetCollection<Site_Device_Data>("DeviceDataAtSite");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var input = JsonConvert.DeserializeObject<MultiDeviceData>(requestBody);
            /*List<sites> sites1 = new List<sites>();*/
            for (int i=0;i<input.Sites.Count;i++)
            {
                var quizUpdateFilter = Builders<Site_Device_Data>.Filter.Eq("site_id", input.Sites[i].site_id) & Builders<Site_Device_Data>.Filter.Eq("device_id", input.Sites[i].device_id);

                var update = Builders<Site_Device_Data>.Update.Set("device_id", input.Sites[i].device_id);
                var update1 = Builders<Site_Device_Data>.Update.Set("alarm", input.Sites[i].alarm);
                var update2 = Builders<Site_Device_Data>.Update.Set("Trouble_count", input.Sites[i].Trouble_count);
                var update3 = Builders<Site_Device_Data>.Update.Set("Description", input.Sites[i].Description);
                var update4 = Builders<Site_Device_Data>.Update.Set("Maintenance_alert", input.Sites[i].Maintainence_alert);
                var update5 = Builders<Site_Device_Data>.Update.Set("RAM_Usage", input.Sites[i].RAM_Usage);
                await collection.UpdateOneAsync(quizUpdateFilter, update);
                await collection.UpdateOneAsync(quizUpdateFilter, update1);
                await collection.UpdateOneAsync(quizUpdateFilter, update2);
                await collection.UpdateOneAsync(quizUpdateFilter, update3);
                await collection.UpdateOneAsync(quizUpdateFilter, update4);
                await collection.UpdateOneAsync(quizUpdateFilter, update5);
                /*sites1.Add(new sites(
                     input.Sites[0].site_id,
                    input.Sites[0].device_id,
                    input.Sites[0].alarm,
                    input.Sites[0].Trouble_count,
                    input.Sites[0].Description,
                     input.Sites[0].Maintainence_alert,
                    input.Sites[0].RAM_Usage

                ));
                */
              
            }
            
            var objectdata = new sites()
            {
                site_id = input.Sites[0].site_id,
                device_id = input.Sites[0].device_id,
                alarm = input.Sites[0].alarm,
                Trouble_count = input.Sites[0].Trouble_count,
                Description = input.Sites[0].Description,
                Maintainence_alert = input.Sites[0].Maintainence_alert,
                RAM_Usage = input.Sites[0].RAM_Usage

            };
            


            /*/
            /*
            var input = JsonConvert.DeserializeObject<DeviceSiteData>(requestBody);
            log.LogInformation("hiii");
            log.LogInformation(input.sitelocation);
            dynamic data;
            int count = 0;
            int flag = 0;
            data = JsonConvert.DeserializeObject(requestBody);
            foreach (JProperty s in data)
            {
                count++;
            }
            var objectdata = new S();

           
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestBody);
            foreach (KeyValuePair<string,string> entry in values)
            {
                log.LogInformation(entry.Key + " : " + entry.Value);
            }
            
            for (int i = 0; i < count; i++)
            {
                if (input.sitelocation.Equals("s121"))
                {
                    for (int j = 0; j < input.s121.Count; j++)
                    {
                        if (input.devicevalue.Equals(input.s121[j].device_id))
                        {
                            objectdata = new S()
                            {
                                site_id = input.s121[j].site_id,
                                device_id = input.s121[j].device_id,
                                alarm = input.s121[j].alarm,
                                Trouble_count = input.s121[j].Trouble_count,
                                Description = input.s121[j].Description,
                                Maintainence_alert = input.s121[j].Maintainence_alert,
                                RAM_Usage = input.s121[j].RAM_Usage

                            };
                            var quizUpdateFilter = Builders<Site_Device_Data>.Filter.Eq("site_id", input.s121[j].site_id) & Builders<Site_Device_Data>.Filter.Eq("device_id", input.s121[j].device_id);

                            var update = Builders<Site_Device_Data>.Update.Set("device_id", input.s121[j].device_id);
                            var update1 = Builders<Site_Device_Data>.Update.Set("alarm", input.s121[j].alarm);
                            var update2 = Builders<Site_Device_Data>.Update.Set("Trouble_count", input.s121[j].Trouble_count);
                            var update3 = Builders<Site_Device_Data>.Update.Set("Description", input.s121[j].Description);
                            var update4 = Builders<Site_Device_Data>.Update.Set("Maintenance_alert", input.s121[j].Maintainence_alert);
                            var update5 = Builders<Site_Device_Data>.Update.Set("RAM_Usage", input.s121[j].RAM_Usage);
                            await collection.UpdateOneAsync(quizUpdateFilter, update);
                            await collection.UpdateOneAsync(quizUpdateFilter, update1);
                            await collection.UpdateOneAsync(quizUpdateFilter, update2);
                            await collection.UpdateOneAsync(quizUpdateFilter, update3);
                            await collection.UpdateOneAsync(quizUpdateFilter, update4);
                            await collection.UpdateOneAsync(quizUpdateFilter, update5);
                            flag = 1;
                            break;
                        }
                    }

                }
                else if (input.sitelocation.Equals("s122"))
                {
                    for (int j = 0; j < input.s122.Count; j++)
                    {
                        if (input.devicevalue.Equals(input.s122[j].device_id))
                        {
                            objectdata = new S()
                            {
                                site_id = input.s122[j].site_id,
                                device_id = input.s122[j].device_id,
                                alarm = input.s122[j].alarm,
                                Trouble_count = input.s122[j].Trouble_count,
                                Description = input.s122[j].Description,
                                Maintainence_alert = input.s122[j].Maintainence_alert,
                                RAM_Usage = input.s122[j].RAM_Usage
                            

                            };
                           
                            flag = 1;
                            break;
                        }
                    }
                }
                if (flag == 1)
                {
                    break;
                }
            }
            log.LogInformation(count.ToString());
            var s2 = input.s121[0].RAM_Usage;
            log.LogInformation(s2.ToString());
            */
            /* var objectdata = new S()
             {
                 site_id = input.s121[0].site_id,
                 device_id = input.s121[0].device_id,
                 alarm = input.s121[0].alarm,
                 Trouble_count = input.s121[0].Trouble_count,
                 Description = input.s121[0].Description,
                 Maintainence_alert = input.s121[0].Maintainence_alert,
                 RAM_Usage = input.s121[0].RAM_Usage

             };
            */
            log.LogInformation($"C# IoT Hub trigger function processed a message: {JsonConvert.SerializeObject(objectdata)}");
            await signalRMessages.AddAsync(new SignalRMessage()
            {
                Target = "notify",
                Arguments = new[] { JsonConvert.SerializeObject(objectdata) }
            });
            /* DeviceAtSiteData[] devicesitedata =JsonConvert.DeserializeObject<DeviceAtSiteData[]>(requestBody);
             log.LogInformation(devicesitedata[0].ToString());



             // John

             /* foreach(var key in input)
                if (input.hasOwnProperty(key))
                    count++;
             */
            /* var dict = JProperty.Parse(requestBody);

             var dict1 = JsonConvert.DeserializeObject<Dictionary<string, string>>(requestBody);
             log.LogInformation("hiiiii");
             foreach (var kv in dict1)
             {
                 Console.WriteLine(kv.Key + ":" + kv.Value);
             }
            */

            /* var s1=input.
             log.LogInformation(s1.ToString());

             /*
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
