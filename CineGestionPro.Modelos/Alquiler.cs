using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGestionPro.Modelos
{
    [Table("Alquileres")]
    public class Alquiler
    {
        [Key]
        [Column("id_alquiler")]
        public int id_alquiler { get; set; }

        [Column("fecha_alquiler")]
        [Required]
        public DateTime fecha_alquiler { get; set; }

        [Column("fecha_devolucion")]
        [Required]
        public DateTime fecha_devolucion { get; set; }

        [Column("costo_total", TypeName = "numeric(10,2)")]
        [Required]
        public decimal costo_total { get; set; }

        [ForeignKey("Usuario")]
        [Column("id_usuario")]
        public int? id_usuario { get; set; }
        public Usuario? Usuario { get; set; }

        //Relaciones
        public List<DetalleAlquiler>? DetalleAlquileres { get; set; }
    }
}
