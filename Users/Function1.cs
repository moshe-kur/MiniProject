using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Entities;

namespace Users
{
    public static class Function1
    {

        //localhost:7***/api*Users/Add
        //localhost:7***/api*Users/Remove
        //localhost:7***/api*Users/Update
        //localhost:7***/api*Users/Get/1234

        //OR
        //localhost:7***/api*Users/Add?action=Add%ID=123





        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "Users/{action}/{IdNumber?}")] HttpRequest req,
            string action, string IdNumber, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            
            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;


            switch (action)
            {
                case "Add":
                    break;
                case "Remove":
                    break;
                case "Update":
                    break;
                case "Get":
                    if (IdNumber==null)
                    {
                          return  new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(MaimManager.Instace.products.getProductFromDB()));

                    }
                    else
                    {
                        return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(MaimManager.Instace.products.getOneProductFromDB(IdNumber)));

                    }

                    break;
                default:
                    break;
            }

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return null;
        }
    }
}
