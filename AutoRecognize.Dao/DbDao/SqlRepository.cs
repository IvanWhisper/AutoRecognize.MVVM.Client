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
    /// 简单数据仓库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        public virtual IEnumerable<T> GetList()
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.GetList<T>();
            }
        }
        public virtual T Get(object id)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.Get<T>(id);
            }
        }
        public virtual bool Update(T t)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.Update(t);
            }
        }
        public virtual T Insert(T apply)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                conn.Insert(apply);
                return apply;
            }
        }
        public virtual bool Delete(T t)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.Delete(t);
            }
        }
        public virtual IEnumerable<T> Find(Expression<Func<T, object>> expression, Operator op, object param)
        {
            using (var conn = ConnectionFactory.CreateSqlConnection())
            {
                return conn.GetList<T>(Predicates.Field<T>(expression, op, param));
            }
        }
    }
}
