using System.ComponentModel.DataAnnotations;

namespace ProductApi.Modlel
{
    public class Product : BaseEntity
    {
        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string ArticleName { get; set; }
    }
}
