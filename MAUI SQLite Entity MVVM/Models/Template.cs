using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_SQLite_Entity_MVVM.Models
{

    [Table(nameof(Template))]
    public partial class Template : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
