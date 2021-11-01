using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

using ToDoApp_Client.Models;
using ToDoAppCommon.Items;
using ToDoApp_Client.Factories;

namespace ToDoApp_Client.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;
        private string _baseAddress;// = "https://localhost:5001/todo/";
        private readonly ItemModelFactory _itemModelFactory;

        public ToDoController(ILogger<HomeController> logger, ItemModelFactory itemModelFactory, IConfiguration config)
        {
            _logger = logger;
            _itemModelFactory = itemModelFactory;
            _config = config;

            _baseAddress = _config.GetValue<string>("todoapp_api_url");
        }

        public IActionResult Index()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri(_baseAddress);

                    HttpResponseMessage result = client.GetAsync("getallitems").Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string stringData = result.Content.ReadAsStringAsync().Result;
                        List<Item> data = JsonConvert.DeserializeObject<List<Item>>(stringData);
                        var items = _itemModelFactory.ToItemsModel(data);
                        return View("List", items);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
            return View();
        }

        // GET: Create TODO
        public ActionResult Create()
        {
            var model = _itemModelFactory.ToItemModel(new Item());
            return View("Create", model);
        }

        [HttpPost]
        // POST: Create Message
        public ActionResult Create( /*[FromBody]*/ ItemViewModel model)
        {
            try
            {
                var item = _itemModelFactory.ToItem(model);

                using (HttpClient client = new HttpClient())
                {
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri(_baseAddress);
                    
                    string stringData = JsonConvert.SerializeObject(item);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8,"application/json");

                    if (model.ID > 0)
                    {
                        HttpResponseMessage result = client.PostAsync("updateitem", contentData).Result;
                        ViewBag.Message = result.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        HttpResponseMessage result = client.PostAsync("additem", contentData).Result;
                        ViewBag.Message = result.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Edit TODO
        public ActionResult Edit(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);

                    HttpResponseMessage result = client.GetAsync($"getitem/{id}").Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string stringData = result.Content.ReadAsStringAsync().Result;
                        Item data = JsonConvert.DeserializeObject<Item>(stringData);
                        
                        var model = _itemModelFactory.ToItemModel(data);
                        return View("Create", model);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
            return View();
        }


        [HttpPost]
        // POST: Update Message
        public ActionResult Edit( /*[FromBody]*/ ItemViewModel model)
        {
            try
            {
                var item = _itemModelFactory.ToItem(model);

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseAddress);

                    string stringData = JsonConvert.SerializeObject(item);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                    if (model.ID > 0)
                    {
                        HttpResponseMessage result = client.PostAsync("updateitem", contentData).Result;
                        ViewBag.Message = result.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        HttpResponseMessage result = client.PostAsync("additem", contentData).Result;
                        ViewBag.Message = result.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri(_baseAddress);
                    HttpResponseMessage result = client.GetAsync($"deleteitem/{id}").Result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}
