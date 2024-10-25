using System.ComponentModel.DataAnnotations;

namespace FinalPro1.Models
{
    public class Member
    {
        [Key]
        public string? MEM_ACCOUNT { get; set; }
        public string? MEM_PASSWORD { get; set; }
        public string? MEM_NAME { get; set; }
        public string? MEM_NICKNAME { get; set; }
    }
}
