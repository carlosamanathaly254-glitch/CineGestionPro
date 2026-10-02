using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGestionPro.Modelos
{
    [Table("Contenido")]
    public class Contenido
    {
        [Key]
        [Column("id_contenido")]
        public int id_contenido { get; set; }

        [Column("titulo")]
        [MaxLength(150)]
        [Required]
        public string titulo { get; set; }

        [Column("tipo")]
        [MaxLength(20)]
        [Required]
        public string tipo  { get; set; }

        [Column("sinopsis", TypeName = "text")]
        [Required]
        public string sinopsis { get; set; }

        [Column("anio_lanzamiento")]
        [Required]
        public int anio_lanzamiento { get; set; }

        [ForeignKey("Categoria")]
        [Column("id_categoria")]
        public int id_categoria { get; set; }
        public Categoria? Categoria { get; set; }

        //Relaciones
        public List<Ejemplar>? Ejemplares { get; set; }
    }
}
