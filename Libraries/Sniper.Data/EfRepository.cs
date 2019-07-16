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

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            if(entity==null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch(DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
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

        #region Utilities

        /// <summary>
        /// 回滚实体更改并返回完整的错误消息
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch
                    {

                    }
                });
               
            }
            try
            {
                _context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        #endregion
    }
}
