using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MVVM_15520419.Models
{
    class FlowerType
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
