﻿using System.Collections.Generic;
using System.Linq;
using LnuCampaign.Core.Data.Entities;

namespace LnuCampaign.Core.Interfaces.DataAccess.Base
{
    public interface IGenericRepository<TEntity, TEntityIdType> where TEntity : IBaseEntity<TEntityIdType>, IIdentifiable<TEntityIdType>, ISaveTrackable, IInactivebleAt
    {
        IQueryable<TEntity> SelectAll(bool isTrackable = false);
        TEntity SelectById(TEntityIdType id, bool throwNotFound = true);
        TEntity Create(TEntity data);
        TEntity Update(TEntity data);
        TEntity Replace(TEntity oldData, TEntity data);
        TEntity Delete(TEntityIdType id, bool throwNotFound = true);
        IQueryable<TEntity> SelectAllByIds(IEnumerable<TEntityIdType> ids, bool isTrackable = false);
        IQueryable<TEntityIdType> SelectAllIds();
        void Save();
    }
}

