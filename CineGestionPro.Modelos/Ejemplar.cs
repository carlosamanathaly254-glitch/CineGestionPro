using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGestionPro.Modelos
{
    [Table("Ejemplares")]
    public class Ejemplar
    {
        [Key]
        [Column("id_ejemplar")]
        public int id_ejemplar { get; set; }

        [Column("codigo_identificacion")]
        [MaxLength(50)]
        [Required]
        public string codigo_identificacion { get; set; }

        [Column("formato")]
        [MaxLength(30)]
        [Required]
        public string formato { get; set; }

        [Column("estado_disponibilidad")]
        [MaxLength(20)]
        [Required]
        public string estado_disponibilidad { get; set; } = "DISPONIBLE";

        [ForeignKey("Contenido")]
        [Column("id_contenido")]
        public int id_contenido { get; set; }
        public Contenido? Contenido { get; set; }

        //Relaciones
        public List<DetalleAlquiler>? DetallesAlquiler { get; set; }
    }
}
