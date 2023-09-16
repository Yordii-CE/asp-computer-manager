using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Control_de_Equipos.Models.ViewModels
{
    public class ResponsibleViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        public int? Id { get; set; }

        public List<Responsible>? Responsibles { get; set; }
    }
}
