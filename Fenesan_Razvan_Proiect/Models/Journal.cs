using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Fenesan_Razvan_Proiect.Models
{
    public class Journal
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
