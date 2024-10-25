using MAUI_SQLite_Entity_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_SQLite_Entity_MVVM.Repositories
{
    public class DatabaseRepository
    {
        private BaseRepository<Template> TemplateRepository { get; set; }

        public DatabaseRepository()
        {
            TemplateRepository = new BaseRepository<Template>();
        }
    }
}
