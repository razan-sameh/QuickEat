using BackEndRestaurant.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebApplication1.Models;

namespace BackEndRestaurant.Controllers
{
    public class CategoryBackController : Controller
    {
        #region TrialPort&Index
        //Uri baseAddress = new Uri("https://localhost:7191/api");
        //private readonly HttpClient _client;
        //public CategoryBackController()
        //{
        //    _client = new HttpClient();
        //    _client.BaseAddress = baseAddress;
        //}

        //Another way
        //private string baseAddressstr = "https://localhost:7191/api";


        //Another way 


        //[HttpGet]
        //public IActionResult Index()
        //{
        //    List<Category> CategorytList = new List<Category>();
        //    HttpResponseMessage resonse = _client.GetAsync(_client.BaseAddress + "/Category/getCategories").Result;
        //    if (resonse.IsSuccessStatusCode)
        //    {
        //        string data = resonse.Content.ReadAsStringAsync().Result;
        //        CategorytList = JsonConvert.DeserializeObject<List<Category>>(data);
        //    }
        //    return View(CategorytList);
        //}
        #endregion

        APIClient _api = new APIClient();

       
        public async Task<IActionResult> Index()
        {
            HttpClient Client = _api.Initial();
            try
            {
                var CategoryList = await Client.GetFromJsonAsync<List<Category>>("api/Category/getCategories");
                return View(CategoryList);
            }
            catch (Exception e)
            {
                return View();
            }

            #region Another Way to get the list of categories
            //List<Category> CategorytList = new List<Category>();
            //HttpClient Client = _api.Initial();
            //HttpResponseMessage response = await Client.GetAsync("api/Category/getCategories");
            //if (response.IsSuccessStatusCode)
            //{
            //    string data = response.Content.ReadAsStringAsync().Result;
            //    CategorytList = JsonConvert.DeserializeObject<List<Category>>(data);
            //}
            //return View(CategorytList);
            #endregion
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Category Category = new Category();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Category/getById/{id}");
            if (res.IsSuccessStatusCode)
            {
                string data = res.Content.ReadAsStringAsync().Result;
                Category = JsonConvert.DeserializeObject<Category>(data);
            }
            return View(Category);
        }

        public async Task<IActionResult> Create()
        {
      
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            //Category Category = new Category();


            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsJsonAsync($"api/Category/Post",category); 
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        #region An Old way for create Method
        //[HttpPost]
        //public IActionResult Create(Category category)
        //{
        //    HttpClient Client = _api.Initial();

        //    var PostCategory = Client.PostAsJsonAsync<Category>("api/Category/Post", category);
        //    PostCategory.Wait();
        //    var data = PostCategory.Result;
        //    if (data.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        #endregion



        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Edit(int id, Category category)
        {
          
                HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PutAsJsonAsync<Category>("api/Category/Put", category);
              
                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
            
            return View(category);
        }
        #region An old way for Editing (Working) 
        //[HttpPost]
        //public ActionResult Edit(int id, Category category)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://localhost:7191/api/");
        //        var putTask = client.PutAsJsonAsync<Category>("Category/Put", category);
        //        putTask.Wait();
        //        var result = putTask.Result;
        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("index");
        //        }
        //    }
        //    return View(category);
        //}
        #endregion


        public ActionResult Delete(int? id)
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            HttpClient Client = _api.Initial();
            HttpResponseMessage res = await Client.DeleteAsync($"api/Category/DeleteCategory/{id}");


            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        #region Another way for deleting
        //public IActionResult Delete(int id)
        //{

        //        HttpClient Client = _api.Initial();
        //        var deleteCategory = Client.DeleteAsync($"api/Category/DeleteCategory/{id}");
        //        deleteCategory.Wait();
        //        var result = deleteCategory.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }


        //    return View();
        //}
        #endregion

        #region Trials
        #region Delete Trial
        //public async Task<IActionResult> Delete(int id)
        //{

        //    HttpClient Client = _api.Initial();
        //    HttpResponseMessage res = await Client.DeleteAsync($"api/Category/deleteCategory/{id}");
        //    if (res.IsSuccessStatusCode)
        //    {

        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        #endregion

        #region Another way Edit

        //public async Task<ActionResult> Edit(Category ctgry)
        //{

        //    using (var client = new HttpClient())
        //    {
        //        var json = JsonConvert.SerializeObject(ctgry);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var request = new HttpRequestMessage
        //        {
        //            Method = HttpMethod.Put,
        //            RequestUri = new Uri("https://localhost:7191/api/"),
        //            Content = content
        //        };

        //        var response = await client.SendAsync(request);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //}

        #endregion

        #region Another Way Edit

        //public async Task<ActionResult> Edit(int id)
        //{
        //    Category ctgry = null;
        //    using (var Client = new HttpClient())
        //    {
        //        Client.BaseAddress = new Uri("https://localhost:7191/api/");
        //        var EditCategory = Client.GetAsync("Category/put?id=" + id.ToString());
        //        EditCategory.Wait();

        //        var result = EditCategory.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadFromJsonAsync<Category>();
        //            readTask.Wait();
        //            ctgry = readTask.Result;
        //        }
        //        return View(ctgry);
        //    }
        //}

    #endregion

        #region The New way for edit
        //public async Task<ActionResult> Edit()
        //{
        //    HttpClient Client = _api.Initial();
        //    var PutCategory = Client.GetAsync("api/Category/Post");
        //    PutCategory.Wait();
        //    var data = PutCategory.Result;
        //    if (data.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //#endregion
        #endregion
    
        #endregion
    }
}
