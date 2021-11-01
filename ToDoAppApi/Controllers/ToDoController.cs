using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.Swagger.Annotations;

using ToDoApp_Api.Models;
using ToDoAppCommon.Items;
using ToDoServices.Items;

namespace ToDoApp_Api.Controllers
{
    [Route("[controller]/[action]")]
    public class ToDoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemService _itemService;

        public ToDoController(ILogger<HomeController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;            
        }
      
        /// <summary>
        ///  Fetches the list of items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            var task = Task.Run(() => _itemService.GetAllItems());
            
            IList<Item> result = await task;            
            
            return result;            
        }


        /// <summary>
        ///  add the item
        /// </summary>
        /// <param name="Item">pass Item as parameter</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> AddItem([FromBody] Item itm)
        {
            var task = Task.Run(() => _itemService.AddItem(itm));
            HttpResponseMessage resp =  await task;

            return resp;
        }

        /// <summary>
        ///  update the item
        /// </summary>
        /// <param name="Item">pass Item as parameter</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<HttpResponseMessage> UpdateItem([FromBody] Item itm)
        {
            var task = Task.Run(() => _itemService.UpdateItem(itm));
            return await task;
        }

        /// <summary>
        ///  delete the item
        /// </summary>
        /// <param name="id">pass id as parameter</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<HttpResponseMessage> DeleteItem(int id)
        {

            var task = Task.Run(() => _itemService.DeleteItem(id));
            return await task;
        }

        /// <summary>
        ///  get item
        /// </summary>
        /// <param name="id">pass id as parameter</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Item> GetItem(int id)
        {
            
            var task = Task.Run(() => _itemService.GetItem(id));
            return await task;
        }

      
    }
}


