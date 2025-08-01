using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_Core.Models
{

    [Table(nameof(Template))]
    public partial class Template : ObservableObject
    {
        static int _nextId = 1;

        private int id;

        [Key]
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set
            {
                id = value;
                //_nextId = Math.Max(_nextId, id + 1);
                OnPropertyChanged(nameof(Id));
            }
        }

    }
}
