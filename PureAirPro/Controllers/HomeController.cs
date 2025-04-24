using Microsoft.AspNetCore.Mvc;
using PureAirPro.DBContext;
using PureAirPro.Models;
using System.Diagnostics;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PureAirPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData.Keep("LoginUser");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CallApi()
        {
            string message = string.Empty;
            using (HttpClient client = new HttpClient())
        {
           try
            {
                // Specify the URL of the API endpoint
                string apiUrl = "http://127.0.0.1:5000/predict_aqi";

                // Send a GET request to the API
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response into a C# object
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);

                    // Extract the predicted values from the response
                    int[] predictedValues = jsonResponse.predicted_values.ToObject<int[]>();

                    // Display the predicted values in the console
                    Console.WriteLine("Predicted AQI Values:");
                    foreach (int value in predictedValues)
                    {
                        message = Convert.ToString(value);
                        Console.WriteLine(value);
                        return Json(message);
                    }
                }
                else
                {
                    Console.WriteLine("Failed to call the API. Status code: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            } 
            return View();
        }
        }
    }
}
