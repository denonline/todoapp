using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

using ToDoAppCommon.Items;

namespace ToDoApp.Repository
{
    public class ItempRepository : IItempRepository
    {
        private readonly IConfiguration configuration;
        ToDoDbContext _context;

        public ItempRepository(ToDoDbContext context, IConfiguration config)
        {
            _context = context;
            configuration = config;            
        }

        public IList<Item> GetAllItems()
        {
            using (_context)
            {
                return _context.Items.ToList();
            }

        }
        public void AddItem(Item itm)
        {
            using (_context)
            {
                _context.Items.Add(itm);
                _context.SaveChanges();
            }

        }

        public Item GetItem(int id)
        {
            using (_context)
            {
               return _context.Items.SingleOrDefault(i => i.ID == id);
            }
        }

        public void DeleteItem(int id)
        {
            using (_context)
            {
                var existingItem = _context.Items.SingleOrDefault(i => i.ID == id);
                if (null != existingItem)
                {
                    _context.Remove(existingItem);
                    _context.SaveChanges();
                }
            }
        }
        
        public void UpdateItem(Item itm)
        {
         
            using (_context)
            {
                var existingItem = _context.Items.SingleOrDefault(i => i.ID == itm.ID);
                if(null != existingItem)
                {
                    existingItem.Name = itm.Name;
                    existingItem.Details = itm.Details;
                    existingItem.DueDate = itm.DueDate;
                    existingItem.Status = itm.Status;

                    _context.SaveChanges();
                }
            }
        }
    }
}
