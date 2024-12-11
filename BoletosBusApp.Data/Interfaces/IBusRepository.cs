using BoletosBusApp.Data.Base;
using BoletosBusApp.Data.Entities.Configuration;
using BoletosBusApp.Data.Models;
using System.Linq.Expressions;

namespace BoletosBusApp.Data.Interfaces
{
    public class IBusRepository : IBaseRepository<Bus, int, BusModel>
    {
        public Task<bool> Exists(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<BusModel>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<List<BusModel>>> GetAll(Expression<Func<Bus, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> Remove(Bus entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> Save(Bus entity)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<BusModel>> Update(Bus entity)
        {
            throw new NotImplementedException();
        }
    }
}
