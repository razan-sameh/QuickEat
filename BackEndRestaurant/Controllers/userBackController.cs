using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace BackEndRestaurant.Controllers
{
    public class UserBackController : Controller
    {
        APIClient _api = new APIClient();
        // GET: UserBackController
        public async Task<IActionResult> Index()
        {

            HttpClient Client = _api.Initial();
            try
            {
                var UsersList = await Client.GetFromJsonAsync<List<User>>("api/User/getUsers");
                return View(UsersList);
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: UserBackController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            User user = new User();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/User/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(data);
            }
            return View(user);
        }

        // GET: UserBackController/Create
        public async Task <IActionResult> Create()
        {
            HttpClient client = _api.Initial();
            //UserType drop down list
            var UserTypeList = await client.GetFromJsonAsync<List<UserType>>("api/UserType/getUserTypes");
            SelectList UserTypesSelectList = new SelectList(UserTypeList, "Id", "Name");
            ViewBag.userTypesList = UserTypesSelectList;
            return View();
        }

        // POST: UserBackController/Create
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/User/Post", user);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: UserBackController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client = _api.Initial();
            //UserType drop down list
            var UserTypeList = await client.GetFromJsonAsync<List<UserType>>("api/UserType/getUserTypes");
            SelectList UserTypesSelectList = new SelectList(UserTypeList, "Id", "Name");
            ViewBag.userTypesList = UserTypesSelectList;
            return View();
        }

        // POST: UserBackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User user)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync("api/User/put", user);

            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }

            return View(user);
        }

        // GET: UserBackController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/User/delete/{id}");
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

     
    }
}