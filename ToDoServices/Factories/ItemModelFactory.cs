using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

using ToDoAppCommon.Items;
using ToDoServices.Models;

namespace ToDoServices.Factories
{
    public class ItemModelFactory : IItemModelFactory
    {
        public IList<ItemModel> ToItemModels(IList<Item> items)
        {
            var itemsModel = items.Select(itm => new ItemModel
            {
                ID = itm.ID,
                Name = itm.Name,
                Details = itm.Details,
                DueDate = itm.DueDate,
                Status = itm.Status

            }).ToList();

            return itemsModel;
        }

        public ItemModel ToItemModel(Item itm)
        {
            var itemModel = new ItemModel
            {
                ID = itm.ID,
                Name = itm.Name,
                Details = itm.Details,
                DueDate = itm.DueDate,
                Status = itm.Status

            };

            return itemModel;
        }
    }
}

