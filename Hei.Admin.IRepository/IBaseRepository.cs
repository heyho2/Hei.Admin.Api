using Hei.Admin.Core;
using Hei.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hei.Admin.IRepository
{
    /// <summary>
    /// 实现对数据库的操作(增删改查)的基类
    /// </summary>
    /// <typeparam name="T">定义泛型，约束其是一个类</typeparam>
    public interface IBaseRepository<T> : IService where T : BaseModel
    {
        DbContext DbContext { get; }

        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> Where(Expression<Func<T, bool>> whereLambda);

        #region 同步

        /// <summary>
        /// 实现对数据库的添加功能,添加实现EF框架的引用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);
        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="proNames">要修改的实体属性</param>
        /// <returns></returns>
        int Update(T entity, params string[] proNames);
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entity">修改内容</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="proNames">要修改的实体属性</param>
        /// <returns></returns>
        int Update(T entity, Expression<Func<T, bool>> whereLambda, params string[] proNames);

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Delete(T entity);
        /// <summary>
        /// 根据条件产出
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        int Delete(Expression<Func<T, bool>> delLambda);

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selected"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        List<TResult> List<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary> 
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        T FirstOrDefault(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="seleced"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        TResult FirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        T Find(params object[] keyValues);
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="order">DESC/ASC</param>
        /// <param name="sort">排序字段</param>
        /// <returns></returns>
        PagingResult<TResult> GetListPaging<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector, int pageIndex, int pageSize, string order, string sort);

        #endregion

        #region 异步
        /// <summary>
        /// 实现对数据库的添加功能,添加实现EF框架的引用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> AddAsync(T entity);

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(T entity);
        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="proNames">要修改的实体属性</param>
        /// <returns></returns>
        Task<int> UpdateAsync(T entity, params string[] proNames);
        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(T entity);
        /// <summary>
        /// 根据条件产出
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(Expression<Func<T, bool>> delLambda);
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="selected"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<List<TResult>> ListAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary> 
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="seleced"></param>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<T> FindAsync(params object[] keyValues);

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="order">DESC/ASC</param>
        /// <param name="sort">排序字段</param>
        /// <returns></returns>
        Task<PagingResult<TResult>> GetListPagingAsync<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector, int pageIndex, int pageSize, string order, string sort);

        #endregion
    }
}