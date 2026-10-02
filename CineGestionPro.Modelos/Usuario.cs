using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CineGestionPro.Modelos
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_usuario")]
        public int id_usuario { get; set; }

        [Column("nombre")]
        [MaxLength(100)]
        [Required]
        public string nombre { get; set; }

        [Column("apellido")]
        [MaxLength(100)]
        [Required]
        public string apellido { get; set; }

        [Column("correo")]
        [MaxLength(100)]
        [Required]
        public string correo_electronico { get; set; }

        [Column("telefono")]
        [MaxLength(10)]
        [Required]
        public string telefono { get; set; }

        [Column("contrasena")]
        [MaxLength(100)]
        [Required]
        public string contrasena { get; set; }

        [Column("fecha_registro")]
        [Required]
        public DateTime fecha_registro { get; set; }

        [ForeignKey("Rol")]
        [Column("id_rol")]
        public int id_rol { get; set; }
        public Rol? Rol { get; set; }

        //Relaciones
        public List<Alquiler>? Alquileres { get; set; }
    }
}
