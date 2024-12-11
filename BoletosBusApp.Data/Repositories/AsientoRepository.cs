using BoletosBusApp.Data.Base;
using BoletosBusApp.Data.Context;
using BoletosBusApp.Data.Entities.Configuration;
using BoletosBusApp.Data.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BoletosBusApp.Data.Repositories
{
    public sealed class AsientoRepository : IAsientoRepository
    {
        private readonly ILogger _logger;
        private readonly BoletoContext _context;

        public AsientoRepository(BoletoContext boletoContext, ILogger<AsientoRepository> logger)
        {
            _context = boletoContext;
            _logger = logger;
        }

        public async Task<OperationResult<List<AsientoModel>>> GetAsientosByBus(int idBus)
        {
            var result = new OperationResult<List<AsientoModel>>();

            try
            {
                // Validación del ID de bus
                if (idBus <= 0)
                {
                    result.Message = "El ID del autobús no es válido.";
                    result.Success = false;
                    return result;
                }

                // Consulta LINQ con filtro por ID de bus
                var query = await (from asiento in _context.Asientos
                                   join bus in _context.Buses on asiento.IdBus equals bus.Id
                                   where asiento.IdBus == idBus && asiento.Estatus == true
                                   orderby asiento.FechaCreacion descending
                                   select new AsientoModel()
                                   {
                                       AsientoId = asiento.Id,
                                       BusId = bus.Id,
                                       Bus = bus.Nombre,
                                       FechaCreacion = asiento.FechaCreacion,
                                       NumeroAsiento = asiento.NumeroAsiento,
                                       NumeroPiso = asiento.NumeroPiso,
                                       FechaModificacion = asiento.FechaModificacion,
                                       UsuarioModificacion = asiento.UsuarioModificacion
                                   }).ToListAsync();

                result.Result = query;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Error obteniendo los asientos de un autobús.";
                result.Success = false;
                _logger.LogError($"{result.Message} Detalle: {ex.Message}");
            }

            return result;
        }

        public Task<bool> Exists(Expression<Func<Asiento, bool>> filter)
        {
            return Task.FromResult(_context.Asientos.Any(filter));
        }

        public async Task<OperationResult<AsientoModel>> Save(Asiento entity)
        {
            var result = new OperationResult<AsientoModel>();
            try
            {
                _context.Asientos.Add(entity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Asiento guardado con éxito.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el asiento.";
                _logger.LogError($"{result.Message} Detalle: {ex.Message}");
            }
            return result;
        }

        public async Task<OperationResult<AsientoModel>> Remove(Asiento entity)
        {
            var result = new OperationResult<AsientoModel>();
            try
            {
                _context.Asientos.Remove(entity);
                await _context.SaveChangesAsync();

                result.Success = true;
                result.Message = "Asiento eliminado con éxito.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el asiento.";
                _logger.LogError($"{result.Message} Detalle: {ex.Message}");
            }
            return result;
        }
    }
}
