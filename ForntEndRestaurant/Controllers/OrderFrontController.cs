using ForntEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace ForntEndRestaurant.Controllers
{
    public class OrderFrontController : Controller
    {
        APIClient _api = new APIClient();



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Order order = new Order();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Order/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                order = JsonConvert.DeserializeObject<Order>(data);
            }
            return View(order);
        }



        public async Task <IActionResult> Create()
        {
            HttpClient client = _api.Initial();
            //Restaurant drop down list
            var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Restaurant/getRestaurants");
            SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");

            ViewBag.RestaurantList = RestaurantsSelectList;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Order/Post", order);
            if (res.IsSuccessStatusCode)
            {
                return View("SuccessOrder");
            }

        return View();
        }

  
    }
}
