using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Entities;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public abstract class InMemoryDal<T> : IEntityRepository<T> where T : IEntity, new()
    {
        protected List<T> _entities = new List<T>();

        public IResult Add(T entity)
        {
            if (_entities.Any(e => e.ID == entity.ID))
                return new Result(false);

            entity.ID = _entities.Count + 1;
            _entities.Add(entity);

            return new Result(true);
        }

        public IResult Delete(T entity)
        {
            _entities.Remove(entity);
            UpdateIDs();
            return new Result(true);
        }

        public IDataResult<T> Get(Expression<Func<T, bool>> filter)
        {
            var data = _entities.SingleOrDefault(filter.Compile());
            return new DataResult<T>(data, true);
        }

        public IDataResult<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null)
        {
            var data = filter == null ? _entities : _entities.Where(filter.Compile());
            return new DataResult<IEnumerable<T>>(data, true);
        }

        public abstract IResult Update(T entity);

        private void UpdateIDs()
        {
            for (int i = 0; i < _entities.Count; i++)
                _entities[i].ID = i + 1;
        }
    }
}
