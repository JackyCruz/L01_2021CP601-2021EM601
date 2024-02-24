using System.ComponentModel.DataAnnotations;

namespace L01_2021CP601_2021EM601.Models
{
    public class platos
    {
        [Key]
        public int platoId { get; set; }
        public string nombrePlato { get; set; }
        public decimal precio { get; set; }

    }
}
