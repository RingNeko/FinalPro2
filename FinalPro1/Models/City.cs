using System.ComponentModel.DataAnnotations;

namespace FinalPro1.Models
{
    public class City
    {
        [Key]
        public string? COU_CODE { get; set; }
        public string? COU_NAME { get; set; }
    }
}
