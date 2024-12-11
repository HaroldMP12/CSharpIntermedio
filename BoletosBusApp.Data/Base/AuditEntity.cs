namespace BoletosBusApp.Data.Base
{
    public abstract class AuditEntity <TType> : BaseEntity<TType>
    {
        public override TType Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacion { get; set; }
        public bool Estatus { get; set; }
    }
}
