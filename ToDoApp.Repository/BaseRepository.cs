using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDoApp.Repository
{
    public abstract class BaseRepository
    {
        protected BaseRepository(IDatabaseConnectionSettings connectionSettings)
        {
            ConnectionSettings = connectionSettings;
        }

        protected IDatabaseConnectionSettings ConnectionSettings { get; set; }
    }
}
