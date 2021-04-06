using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LnuCampaign.Core.Data.Entities;

namespace LnuCampaign.Core.Interfaces.DataAccess
{
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> FindByIdAsync(params object[] keys);

        Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entity);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entity);

        void Update(TEntity entity);

        Task Update(TEntity entity, IEnumerable<string> fieldMasks);

        Task<int> SaveChangesAsync();
    }
}
