using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGestionPro.Modelos
{
    [Table("Roles")]
    public class Rol
    {
        [Key]
        [Column("id_rol")]
        public int id_rol { get; set; }

        [Column("nombre_rol")]
        [MaxLength(50)]
        [Required]
        public string nombre_rol { get; set; }

        //Relaciones
        public List<Usuario>? Usuarios { get; set; }
    }
}
