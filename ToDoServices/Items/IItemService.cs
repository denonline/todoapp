using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using ToDoAppCommon.Items;

namespace ToDoServices.Items
{
    public interface IItemService
    {
        IList<Item> GetAllItems();
        Item GetItem(int id);
        HttpResponseMessage AddItem(Item itm);
        HttpResponseMessage DeleteItem(int id);
        HttpResponseMessage UpdateItem(Item itm);
    }
}

