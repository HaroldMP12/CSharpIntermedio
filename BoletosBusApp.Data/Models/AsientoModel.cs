using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBusApp.Data.Models
{
    public int AsientoId { get; set; }
    public int BusId { get; set; }
    public string? Bus { get; set; }
    public int NumeroPiso { get; set; }
    public int NumeroAsiento { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public int? UsuarioModificacion { get; set; }
}
