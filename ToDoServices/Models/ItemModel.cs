using System;
using ToDoAppCommon.Items;

namespace ToDoServices.Models
{
    public class ItemModel
    { 
        public ItemModel()
        {
            Status = ItemStatus.PENDING;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
        public ItemStatus Status { get; set; }
    }
   
}


