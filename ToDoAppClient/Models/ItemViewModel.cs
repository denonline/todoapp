using System;

using ToDoAppCommon.Items;

namespace ToDoApp_Client.Models
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
        public ItemStatus Status { get; set; }
    }
}
