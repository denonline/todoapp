using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

using ToDoAppCommon.Items;
using ToDoServices.Models;

namespace ToDoServices.Factories
{
    public interface IItemModelFactory
    {
        IList<ItemModel> ToItemModels(IList<Item> items);
        ItemModel ToItemModel(Item itm);
    }
}

