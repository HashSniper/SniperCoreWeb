using Microsoft.EntityFrameworkCore;
using Sniper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Data
{
    public partial interface IDbContext
    {
        /// <summary>
        /// 创建可用于查询和保存实体实例的DbSet
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// 所有更改保存到数据库中
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 生成脚本以为当前模型创建所有表
        /// </summary>
        /// <returns></returns>
        string GenerateCreateScript();

        /// <summary>
        /// 基于原始SQL查询为查询类型创建LINQ查询
        /// </summary>
        /// <typeparam name="TQuery"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TQuery> QueryFromSql<TQuery>(string sql, params object[] parameters) where TQuery : class;

        /// <summary>
        /// 基于原始SQL查询为实体创建LINQ查询
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> EntityFromSql<TEntity>(string sql, params object[] parameters) where TEntity : class;

        /// <summary>
        /// 对数据库执行给定的SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="doNotEnsureTransaction"></param>
        /// <param name="timeout"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteSqlCommand(RawSqlString sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters);

        /// <summary>
        /// 从上下文中分离实体
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;


    }
}
