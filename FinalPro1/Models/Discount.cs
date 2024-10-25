using System.ComponentModel.DataAnnotations;

namespace FinalPro1.Models
{
    public class Discount
    {
        [Key]
        [Required]
        [RegularExpression(@"^[a-zA-Z]\d{2}$", ErrorMessage ="需為字母開頭，且數字僅能有兩位")]
        public string? DIS_ID { get; set; }
        public string? DIS_NAME { get; set; }
        [Display(Name = "DIS_START")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DIS_START { get; set; }
        [Display(Name = "DIS_END")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DIS_END { get; set; }
    }
}
