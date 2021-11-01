using System;

namespace ToDoAppCommon.Items
{
    public class Item
    { 
        public Item()
        {
            Status = ItemStatus.PENDING;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public DateTime DueDate { get; set; }
        public ItemStatus Status { get; set; }
    }

    public enum ItemStatus
    { 
        PENDING,
        COMPLETED,
        CANCELLED
    }
}


