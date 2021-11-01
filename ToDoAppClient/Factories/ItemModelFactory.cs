using System;
using System.Collections.Generic;

using ToDoAppCommon.Items;
using ToDoApp_Client.Models;

namespace ToDoApp_Client.Factories
{
    public class ItemModelFactory
    {

        public ItemViewModel ToItemModel(Item itm)
        {
            var model = new ItemViewModel
            {
                ID = itm.ID,
                Name = itm.Name,
                Details = itm.Details,
                DueDate = itm.DueDate,
                Status = itm.Status
            };
            return model;
        }

        public ItemsViewModel ToItemsModel(IList<Item> items)
        {
            var model = new ItemsViewModel();
            model.Items = new List<ItemViewModel>();

            foreach (var item in items)
            {
                model.Items.Add(this.ToItemModel(item));
            }
            return model;
        }


        public Item ToItem(ItemViewModel itm)
        {
            var item = new Item
            {
                ID = itm.ID,
                Name = itm.Name,
                Details = itm.Details,
                DueDate = itm.DueDate,
                Status = itm.Status
            };
            return item;
        }
    }
}
