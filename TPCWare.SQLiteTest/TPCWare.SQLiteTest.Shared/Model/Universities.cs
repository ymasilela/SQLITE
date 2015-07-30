using SQLite;

namespace TPCWare.SQLiteTest.Model
{
    [Table("Universities")]
    public class Universities
    {
        [PrimaryKey, AutoIncrement]
      

        public string Name { get; set; }

        

    }
}



