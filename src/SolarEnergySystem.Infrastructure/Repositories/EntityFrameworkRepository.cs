using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolarEnergySystem.Core.Entities;
using SolarEnergySystem.Core.Interfaces;

namespace SolarEnergySystem.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        private readonly SolarEnergySystemDatabaseContext _context;

        public EntityFrameworkRepository(SolarEnergySystemDatabaseContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public TEntity GetById(TKey key)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(key));
        }

        public IReadOnlyList<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
