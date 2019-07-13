using Microsoft.EntityFrameworkCore;
using Sniper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Data
{
    public partial class NopObjectContext : DbContext, IDbContext
    {

        #region Ctor
        public NopObjectContext(DbContextOptions<NopObjectContext> options) : base(options)
        {
        }
        #endregion

        #region Methods
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public string GenerateCreateScript()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
