using System;
using System.Collections.Generic;

using ToDoAppCommon.Items;

namespace ToDoApp_Client.Models
{
    public class ItemsViewModel
    {
        public IList<ItemViewModel> Items { get; set; }
    }
}
