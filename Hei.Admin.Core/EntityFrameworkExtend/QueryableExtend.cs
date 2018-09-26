using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Hei.Admin.Core.EntityFrameworkExtend
{
   public static class QueryableExtend
    {
        /// <summary>
        /// 根据字段名排序
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="query">IQueryable集合</param>
        /// <param name="sort">字段名</param>
        /// <param name="order">排序方向</param>
        /// <returns></returns>
        public static IQueryable<T> SetQueryableOrder<T>(this IQueryable<T> query, string sort, string order)
        {
            if (string.IsNullOrEmpty(sort))
                throw new Exception("必须指定排序字段!");

            PropertyInfo sortProperty = typeof(T).GetProperty(sort, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            if (sortProperty == null)
                throw new Exception("查询对象中不存在排序字段" + sort + "！");

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression body = param;
            if (Nullable.GetUnderlyingType(body.Type) != null)
                body = Expression.Property(body, "Value");
            body = Expression.MakeMemberAccess(body, sortProperty);
            LambdaExpression keySelectorLambda = Expression.Lambda(body, param);

            if (string.IsNullOrEmpty(order))
                order = "ASC";
            string queryMethod = order.ToUpper() == "DESC" ? "OrderByDescending" : "OrderBy";
            query = query.Provider.CreateQuery<T>(Expression.Call(typeof(Queryable), queryMethod,
                                                               new Type[] { typeof(T), body.Type },
                                                               query.Expression,
                                                               Expression.Quote(keySelectorLambda)));
            return query;
        }
    }
}
    