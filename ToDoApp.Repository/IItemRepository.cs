using System.Collections.Generic;

using ToDoAppCommon.Items;

namespace ToDoApp.Repository
{
    public interface IItempRepository
    {
        IList<Item> GetAllItems();
        Item GetItem(int id);
        void AddItem(Item itm);
        void DeleteItem(int id);
        void UpdateItem(Item itm);
    }
}
