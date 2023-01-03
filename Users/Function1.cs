using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Entities;
using Model;
using System;

namespace Users
{
    public static class Function1
    {

        


        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post","update","delete", Route = "Products/{action}/{IdNumber?}")] HttpRequest req,
            string action, string IdNumber, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");


            
            string name = req.Query["name"];

          

                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            switch (action)
            {
                case "Add":

                    break;
                case "Remove":
                    try
                    {
                        MaimManager.Instace.products.deleteProductFromDB(requestBody);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                        throw;
                    }
                    break;
                case "Update":
                    try
                    {

                    Model.Product product = System.Text.Json.JsonSerializer.Deserialize<Model.Product>(requestBody);
                    MaimManager.Instace.products.sendUpdateProductToDB(product);

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }

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

            return null;
        }
    }
}
