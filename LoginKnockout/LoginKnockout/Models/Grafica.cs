namespace LoginKnockout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Grafica")]
    public partial class Grafica
    {
        public int GraficaId { get; set; }

        public int Edad { get; set; }
    }
}
