using System.ComponentModel.DataAnnotations;

namespace FinalPro1.Models
{
    public class Store
    {
        [Key]
        public string? STORE_ID { get; set; }
        public string? STORE_NAME { get; set; }
        public string? STORE_ADDRESS { get; set; }
        public string? COU_CODE { get; set; }
    }
}
