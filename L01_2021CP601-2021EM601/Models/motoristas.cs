using System.ComponentModel.DataAnnotations;

namespace L01_2021CP601_2021EM601.Models
{
    public class motoristas
    {
        [Key]
        public int motoristaId { get; set; }
        public string nombreMotorista { get; set; }
        
    }
}

