using System.ComponentModel.DataAnnotations;

namespace Sistema_de_Control_de_Equipos.Models.ViewModels
{
    public class ModelViewModel
    {
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }

        public int? Id{ get; set; }


        public List<Model>? Models { get; set; }
    }
}
