using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoApp.Repository
{
    public interface IDatabaseConnectionSettings
    {
        string Environment { get; set; }
        string ConnectionStringName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
