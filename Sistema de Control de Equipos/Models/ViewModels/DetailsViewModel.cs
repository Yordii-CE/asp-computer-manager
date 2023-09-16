using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Control_de_Equipos.Models.ViewModels
{
    public class DetailsViewModel
    {               
        public int PcId { get; set; }
        public string PcSerial { get; set; }
        public int? Id { get; set; }

        [Display(Name = "Descripcion del problema")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Numero de serie")]
        public string Serial { get; set; }

        [Display(Name = "Capacidad - Especificacion (Opcional)")]
        public string? Specification { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Modelo")]
        public int ModelId { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int BrandId { get; set; }

        public List<dynamic>? Components { get; set; }
        public List<dynamic>? Problems{ get; set; }
    }
}
