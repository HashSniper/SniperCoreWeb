using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sniper.Core.Data
{
    public partial interface IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Methods
        /// <summary>
        /// 根据实体获取id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetById(object id);

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="entity"></param>
        void Insert(TEntity entity);

        /// <summary>
        /// 列表插入
        /// </summary>
        /// <param name="entities"></param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 列表更新
        /// </summary>
        /// <param name="entities"></param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 列表删除
        /// </summary>
        /// <param name="entities"></param>
        void Delete(IEnumerable<TEntity> entities);

        #endregion

        #region Properties
        IQueryable<TEntity> Table { get; }

        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }
}
