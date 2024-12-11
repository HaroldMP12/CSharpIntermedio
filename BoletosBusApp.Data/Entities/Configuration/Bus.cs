using BoletosBusApp.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace BoletosBusApp.Data.Entities.Configuration
{
    [Table("Bus", Schema = "dbo")]
    public sealed class Bus : AuditEntity<int>
    {
        [Key]
        [Column("IdBus")]
        public override int Id { get; set; }
        public string? NumeroPlaca { get; set; }
        public string? Nombre { get; set; }
        public int CapacidadPiso1 { get; set; }
        public int CapacidadPiso2 { get; set; }
        public bool Disponible { get; set; }
    }
}
