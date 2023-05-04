using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace BackEndCategory.Controllers
{
    public class FoodServedBackController : Controller
    {
        APIClient _api = new APIClient();
       
        public async Task<IActionResult> Index()
        {

            HttpClient Client = _api.Initial();
            try
            {
                var foodServedList = await Client.GetFromJsonAsync<List<FoodServed>>("api/FoodServed/getFoodServed");
                return View(foodServedList);
            }
            catch (Exception e)
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            FoodServed foodServed = new FoodServed();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/FoodServed/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                foodServed = JsonConvert.DeserializeObject<FoodServed>(data);
            }
            return View(foodServed);
        }

        public async Task<IActionResult> Create()
        {
            HttpClient client = _api.Initial();
            //Category drop down list
            var categoryList = await client.GetFromJsonAsync<List<Category>>("api/Category/getCategories");
            SelectList CategoriesSelectList = new SelectList(categoryList, "Id", "Name");

            ViewBag.CategoryList = CategoriesSelectList;

            //Restaurant drop down list
            var restaurantList = await client.GetFromJsonAsync<List<Restaurant>>("api/Restaurant/getRestaurants");
            SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");

            ViewBag.RestaurantList = RestaurantsSelectList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FoodServed foodServed)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/FoodServed/Post", foodServed); 
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        } 

        public async Task<IActionResult> Edit(int id)
        {
            HttpClient Client = _api.Initial();
            try
            {
                //Category drop down list
                var categoryList = await Client.GetFromJsonAsync<List<Category>>("api/Category/getCategories");
                SelectList CategoriesSelectList = new SelectList(categoryList, "Id", "Name");

                ViewBag.CategoryList = CategoriesSelectList;

                //Restaurant drop down list
                var restaurantList = await Client.GetFromJsonAsync<List<Restaurant>>("api/Restaurant/getRestaurants");
                SelectList RestaurantsSelectList = new SelectList(restaurantList, "Id", "Name");

                ViewBag.RestaurantList = RestaurantsSelectList;

                return View();
            }
            catch (Exception e)
            {
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, FoodServed foodServed)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync("api/FoodServed/Put", foodServed);     
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View(foodServed);
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
                HttpResponseMessage res = await Client.DeleteAsync($"api/FoodServed/delete/{id}");
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            return View();
        }
    }
}