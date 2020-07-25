using System;

namespace DiarySample.Dao
{
    public class Diary
    {
        public int Id { get; set; }
        public DateTime RelatedDate { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
