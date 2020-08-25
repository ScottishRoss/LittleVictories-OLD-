using SQLite;
using System;

namespace LittleVictories.Models
{
    public class TheVictory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(34)]
        public string Title { get; set; }
        public string Quick { get; set; }
        [MaxLength(140)]
        public string Details { get; set; }
        public DateTime Date { get; set; }
    }

    public class QuickVictories
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength (140)]
        public string Desc { get; set; }
        [AutoIncrement]
        public int DisplaySeq { get; set; }
    }
}