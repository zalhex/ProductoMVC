using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVCnet5.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es requerido")]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es requerida")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es requerido")]
        [Display(Name = "Precio MXN")]
        public decimal Precio { get; set; }
        [Display(Name = "Activo")]
        public bool Activo { get; set; }
        [Display(Name = "Fecha de alta")]
        public DateTime FechaDeAlta { get; set; }
    }
}
