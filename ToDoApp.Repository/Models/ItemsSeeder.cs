using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection;

using ToDoAppCommon.Items;

namespace ToDoApp.Repository
{
    public static class ItemsSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var ctx = serviceProvider.GetRequiredService<ToDoDbContext>();

            using (var context = new ToDoDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ToDoDbContext>>()))
            {
                // Look for any items.
                if (context.Items.Any())
                {
                    return;   // DB has been seeded
                }

                context.Items.AddRange(
                    new Item
                    {
                        Name = "ToDo # 1",
                        Details = "details for do do #1",
                        DueDate = DateTime.Parse("1/1/2022")
                    },

                    new Item
                    {
                        Name = "ToDo # 2",
                        Details = "details for do do #2",
                        DueDate = DateTime.Parse("1/1/2022")
                    },

                    new Item
                    {
                        Name = "ToDo # 3",
                        Details = "details for do do #3",
                        DueDate = DateTime.Parse("1/1/2022")
                    }
                ); ;
                context.SaveChanges();
            }
        }
    }
}
