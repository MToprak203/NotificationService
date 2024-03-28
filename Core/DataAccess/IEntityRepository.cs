using Core.Utilities.Results.Abstract;
using Entities;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IEntityRepository<T> where T : IEntity, new()
    {
        IDataResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);
        IDataResult<T> Get(Expression<Func<T, bool>> filter);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
