using System.ComponentModel.DataAnnotations;

namespace TeprestpApi.Models
{
    public class Ocupaciones
    {
        [Key]
        public int OcupacionId { get; set; }
        
        public string? Descripcion { get;set; }

        public double? sueldo { get; set; }  

    }
}
