using System;
using SQLite;

namespace LittleVictories.Models
{
    public class TheVictory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Quick { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
    }
}