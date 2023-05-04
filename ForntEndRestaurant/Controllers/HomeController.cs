using ForntEndRestaurant.Models;
using ForntEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForntEndRestaurant.Controllers
{
    public class HomeController : Controller
    {
        APIClient _api = new APIClient();

        private readonly ILogger<HomeController> _logger;
        //string baseURL = "https://localhost:7191/";
        //Uri baseAddress = new Uri("https://localhost:44388/api");
        //private readonly HttpClient _client;
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_client = new HttpClient();
            //_client.BaseAddress = baseAddress;
        }

        public async Task<IActionResult> Index() {
            HttpClient Client = _api.Initial();

            //Restaurant drop down list
            var restaurantList = await Client.GetFromJsonAsync<List<Restaurant>>("api/Restaurant/getRestaurants");
            SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");

            ViewBag.RestaurantList = RestaurantsSelectList;

            return View();
        }

        private MediaTypeWithQualityHeaderValue MediaTypeWithQualityHeaderValue(string v)
        {
            throw new NotImplementedException();
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
    }
}