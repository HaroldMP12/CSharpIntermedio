using BoletosBusApp.Data.Base;
using BoletosBusApp.Data.Entities.Configuration;
using BoletosBusApp.Data.Models;

namespace BoletosBusApp.Data.Interfaces
{
    public interface IAsientoRepository : IBaseRepository<Asiento, int, AsientoBusModel>
    {
        public Task<OperationResult<List<AsientoBusModel>>> GetAsientosByBus(int idBus);
    }
}
