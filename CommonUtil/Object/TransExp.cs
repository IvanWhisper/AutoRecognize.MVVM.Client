using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtil.Object
{
    /*快速高效率复制对象另一种方式 表达式树 调用一百万次耗时：107毫秒*/
    /// <summary>
    /// 高效率复制对象
    /// </summary>
    /// <typeparam name="TIn">输入类型</typeparam>
    /// <typeparam name="TOut">输出类型</typeparam>
    public static class TransExp<TIn, TOut>
    {
        //调用
        //StudentSecond ss= TransExpV2<Student, StudentSecond>.Trans(s);
        /// <summary>
        /// 委托
        /// </summary>
        private static readonly Func<TIn, TOut> cache = GetFunc();
        /// <summary>
        /// CopyObject
        /// </summary>
        /// <returns></returns>
        private static Func<TIn, TOut> GetFunc()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach (var item in typeof(TOut).GetProperties())
            {
                try {
                    if (!item.CanWrite)
                        continue;
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                catch
                {
                    continue;
                }
            }
            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[] { parameterExpression });
            return lambda.Compile();
        }
        /// <summary>
        /// CopyObject
        /// </summary>
        /// <param name="tIn">源对象</param>
        /// <returns></returns>
        public static TOut Trans(TIn tIn)
        {
            return cache(tIn);
        }
    }
}
