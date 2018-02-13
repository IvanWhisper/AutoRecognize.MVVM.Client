using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoRecognize.Dao.DbDao
{
    /// <summary>
    /// 数据仓库接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetList();
        /// <summary>
        /// 查找全部数据对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(object id);
        /// <summary>
        /// 更新数据对象
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);
        /// <summary>
        /// 插入数据对象
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        T Insert(T apply);
        /// <summary>
        /// 删除数据对象
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);
        /// <summary>
        /// 根据对象查找对象集合
        /// </summary>
        /// <param name="expression">带参委托</param>
        /// <param name="op">执行对象</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        IEnumerable<T> Find(Expression<Func<T, object>> expression, Operator op, object param);
    }
}
