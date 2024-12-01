using RefactoringGenerics.Class;

namespace RefactoringGenerics.Interfaces
{
    public interface IBaseRepository <TEntity, TResult, TResultList> where TEntity : class
    {
        Task <TResult> Save(TEntity entity);
        Task <TResult> Update(TEntity entity);
        Task <TResult> Remove(TEntity entity);
        Task <TResultList> GetAll();
        Task<TResultList> GetAll(Func<TEntity, bool> filter);
        Task<TResult> GetEntityBy(int Id);
        Task<bool> Exists(Func<TEntity, bool> filter);
    }
}
