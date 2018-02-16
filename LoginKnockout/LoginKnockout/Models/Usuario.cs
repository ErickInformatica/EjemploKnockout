namespace LoginKnockout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string Correo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Comentario { get; set; }

        public int OpinionId { get; set; }

        [StringLength(25)]
        public string Pass { get; set; }

        public virtual Opinion Opinion { get; set; }
    }
}
