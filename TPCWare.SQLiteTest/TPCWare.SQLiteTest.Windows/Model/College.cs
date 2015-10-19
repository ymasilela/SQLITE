using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TPCWare.SQLiteTest.Model
{
    [Table("Colleges")]
    public class College
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

    }
}
