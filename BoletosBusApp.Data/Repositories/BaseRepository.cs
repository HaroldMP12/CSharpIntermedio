using BoletosBusApp.Data.Base;
using BoletosBusApp.Data.Interfaces;
using System.Linq.Expressions;

namespace BoletosBusApp.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TType, TModel> : IBaseRepository<TEntity, TType, TModel> where TEntity : class
    {
        public Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Task<OperationResult<List<TModel>>> IBaseRepository<TEntity, TType, TModel>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<OperationResult<List<TModel>>> IBaseRepository<TEntity, TType, TModel>.GetAll(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Task<OperationResult<TModel>> IBaseRepository<TEntity, TType, TModel>.GetEntityBy(TType Id)
        {
            throw new NotImplementedException();
        }

        Task<OperationResult<TModel>> IBaseRepository<TEntity, TType, TModel>.Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<OperationResult<TModel>> IBaseRepository<TEntity, TType, TModel>.Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<OperationResult<TModel>> IBaseRepository<TEntity, TType, TModel>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
