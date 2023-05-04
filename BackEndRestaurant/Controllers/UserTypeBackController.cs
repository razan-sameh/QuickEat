using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace BackEndRestaurant.Controllers
{
    public class UserTypeBackController : Controller
    {
        APIClient _api = new APIClient();

        // GET: UserTypesController
        public async Task<IActionResult> Index()
        {

            HttpClient Client = _api.Initial();
            try
            {
                var UserTypesList = await Client.GetFromJsonAsync<List<UserType>>("api/UserType/getUserTypes");
                return View(UserTypesList);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: UserTypesController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            UserType userType = new UserType();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/UserType/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                userType = JsonConvert.DeserializeObject<UserType>(data);
            }
            return View(userType);
        }

        // GET: UserTypesController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserType userType)
        {
           

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/UserType/Post", userType);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: UserTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Edit(int id, UserType userType)
        {

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync<UserType>("api/UserType/put", userType);

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View(userType);
        }

        // GET: UserTypesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/UserType/delete/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
