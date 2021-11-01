using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ToDoServices.Models
{
    public class ItemsModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("items")]
        public IList<ItemModel> Items { get; set; }
    }  
}


