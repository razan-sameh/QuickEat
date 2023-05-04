using ForntEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace ForntEndRestaurant.Controllers
{
    public class RestaurantBackController : Controller
    {
        APIClient _api = new APIClient();


        public async Task<ActionResult<IEnumerable<Restaurant>>> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var RestaurantsList = await Client.GetFromJsonAsync<List<Restaurant>>("api/Restaurant/getRestaurants");
                return View(RestaurantsList);
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Restaurant Restaurant = new Restaurant();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Restaurant/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = await res.Content.ReadAsStringAsync();
                Restaurant = JsonConvert.DeserializeObject<Restaurant>(data);
            }
            return View(Restaurant);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Restaurant restaurant)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Restaurant/Post", restaurant);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Restaurant restaurant)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync("api/Restaurant/Put", restaurant);

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View(restaurant);
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/Restaurant/delete/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
