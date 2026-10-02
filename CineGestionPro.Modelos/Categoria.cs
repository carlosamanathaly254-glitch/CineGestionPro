using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGestionPro.Modelos
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        [Column("id_categoria")]
        public int id_categoria { get; set; }

        [Column("nombre_categoria")]
        [MaxLength(100)]
        [Required]
        public string nombre_categoria { get; set; }

        [Column("descripcion_categoria", TypeName = "text")]
        [Required]
        public string descripcion_categoria { get; set; }

        //Relaciones
        public List<Contenido>? Contenidos { get; set; }
    }
}
