using Microsoft.EntityFrameworkCore;
using Sniper.Core;
using Sniper.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Data
{
    public partial class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fileds
        private readonly IDbContext _context;

        private DbSet<TEntity> _entities;

        #endregion

        #region Ctor
        public EfRepository(IDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Properties

        public IQueryable<TEntity> Table => Entities;

        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();


        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _context.Set<TEntity>();
                }
                return _entities;
            }
        }
        #endregion

        #region  Methods

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
