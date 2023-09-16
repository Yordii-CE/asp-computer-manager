using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Control_de_Equipos.Models.ViewModels
{
    public class PcViewModel
    {
        [Display(Name = "Codigo de equipo")]
        public string Serial { get; set; }

        [Required]
        [Display(Name = "Responsable")]
        public int ResponsibleId { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Propietario")]
        public string Owner { get; set; }


        [Display(Name = "Observaciones (Opcional)")]
        public string? Observations { get; set; }

        public List<Pc>? Pcs { get; set; }
    }
}
