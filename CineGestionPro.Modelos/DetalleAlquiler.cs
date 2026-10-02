using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGestionPro.Modelos
{
    [Table("detalle_alquiler")]
    public class DetalleAlquiler
    {
        [Key]
        [Column("id_detalle")]
        public int id_detalle { get; set; }

        [Column("precio_unitario", TypeName = "numeric(10,2)")]
        [Required]
        public decimal precio_unitario { get; set; }

        [Column("fecha_devolucion_real")]
        [Required]
        public DateTime fecha_devolucion_real { get; set; }

        [ForeignKey("Alquiler")]
        [Column("id_alquiler")]
        public int id_alquiler { get; set; }
        public Alquiler? Alquiler { get; set; }

        [ForeignKey("Ejemplar")]
        [Column("id_ejemplar")]
        public int id_ejemplar { get; set; }
        public Ejemplar? Ejemplar { get; set; }
    }
}
