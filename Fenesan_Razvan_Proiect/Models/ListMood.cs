using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Fenesan_Razvan_Proiect.Models
{
    public class ListMood
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Journal))]
        public int JournalID { get; set; }
        public int MoodID { get; set; }
    }
}
