using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SolarEnergySystem.Core.Entities;

namespace SolarEnergySystem.Core.Interfaces
{
    public interface IRepository<TEntity, TKey>
    {
        void Add(TEntity entity);

        TEntity GetById(TKey key);

        IReadOnlyList<TEntity> GetAll();
    }
}
