using System;
using System.ComponentModel.DataAnnotations;

namespace DiarySample.Dao
{
    public class Diary
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [Display(Name ="日付")]
        public DateTime RelatedDate { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="タイトル")]
        public string Title { get; set; }
        [StringLength(1000)]
        [Display(Name ="本文")]
        public string Body { get; set; }
    }
}
