using MAUI_SQLite_Entity_MVVM.Models;
using MAUI_SQLite_Entity_MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_SQLite_Entity_MVVM.Services
{
    public class TemplateService : BaseService<Template>
    {
        public TemplateService(DatabaseRepository databaseRepository)
            : base(databaseRepository) {
        }
    }
}
