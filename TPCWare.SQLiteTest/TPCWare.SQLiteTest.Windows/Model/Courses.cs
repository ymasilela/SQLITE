using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TPCWare.SQLiteTest.Model
{
    [Table("Courses")]
    public class Courses
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string courses { get; set; }

    }
}
