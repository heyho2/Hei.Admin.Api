using Hei.Admin.Core.EntityFrameworkExtend;
using Hei.Admin.IRepository;
using Hei.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Hei.Admin.Repository
{
    /// <summary>
    /// 实现对数据库的操作(增删改查)的基类
    /// </summary>
    /// <typeparam name="T">定义泛型，约束其是一个类</typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public DbContext DbContext { get; }
        public BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().AsNoTracking().Where<T>(whereLambda).AsQueryable();
        }

        #region 同步
        public int Add(T entity)
        {
            DbContext.Entry<T>(entity).State = EntityState.Added;
            return DbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry<T>(entity).State = EntityState.Modified;
            return DbContext.SaveChanges();
        }

        public int Update(T entity, params string[] proNames)
        {
            var entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Unchanged;
            foreach (var item in proNames)
            {
                entry.Property(item).IsModified = true;
            }
            return DbContext.SaveChanges();
        }
        public int Update(T entity, Expression<Func<T, bool>> whereLambda, params string[] proNames)
        {
            var listModifes = DbContext.Set<T>().Where(whereLambda).ToList();
            Type t = typeof(T);
            var proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dicPros = new Dictionary<string, PropertyInfo>();
            proInfos.ForEach(a =>
            {
                if (proNames.Contains(a.Name))
                {
                    dicPros.Add(a.Name, a);
                }
            });
            foreach (var item in proNames)
            {
                if (dicPros.ContainsKey(item))
                {
                    PropertyInfo proInfo = dicPros[item];
                    object newValue = proInfo.GetValue(entity, null);
                    foreach (var m in listModifes)
                    {
                        proInfo.SetValue(m, newValue, null);
                    }
                }
            }
            return DbContext.SaveChanges();
        }

        public int Delete(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry<T>(entity).State = EntityState.Deleted;
            return DbContext.SaveChanges();
        }

        public int Delete(Expression<Func<T, bool>> delLambda)
        {
            var ListDel = DbContext.Set<T>().Where(delLambda).ToList();
            ListDel.ForEach(a =>
            {
                DbContext.Set<T>().Attach(a);
                DbContext.Entry<T>(a).State = EntityState.Deleted;
            });
            return DbContext.SaveChanges();
        }


        public T FirstOrDefault(Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().AsNoTracking().FirstOrDefault<T>(whereLambda);
        }

        public T Find(params object[] keyValues)
        {
            return DbContext.Set<T>().Find(keyValues);
        }

        public PagingResult<TResult> GetListPaging<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector, int pageIndex, int pageSize, string order, string sort)
        {
            var temp = DbContext.Set<T>().Where<T>(whereLambda);
            var count = temp.Count();
            temp = temp.SetQueryableOrder(sort, order).Skip(pageSize * (pageIndex - 1))
                     .Take(pageSize);
            var list = temp.Select(selector).ToList();
            return new PagingResult<TResult>
            {
                Count = count,
                Items = list,
                Index = pageIndex,
                Size = pageSize,
                Total = count % pageSize == 0 ? count / pageSize : count / pageSize + 1
            };
        }

        public List<TResult> List<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().Where(whereLambda).Select(selector).ToList();
        }

        public TResult FirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().Where(whereLambda).Select(selector).FirstOrDefault();
        }
        #endregion

        #region 异步
        public async Task<int> AddAsync(T entity)
        {
            DbContext.Entry<T>(entity).State = EntityState.Added;
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry<T>(entity).State = EntityState.Modified;
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity, params string[] proNames)
        {
            var entry = DbContext.Entry<T>(entity);
            entry.State = EntityState.Unchanged;
            foreach (var item in proNames)
            {
                entry.Property(item).IsModified = true;
            }
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Deleted;
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> delLambda)
        {
            var ListDel = await DbContext.Set<T>().Where(delLambda).ToListAsync();
            ListDel.ForEach(a =>
            {
                DbContext.Set<T>().Attach(a);
                DbContext.Entry<T>(a).State = EntityState.Deleted;
            });
            return await DbContext.SaveChangesAsync();
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await DbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync<T>(whereLambda);
        }

        public async Task<T> FindAsync(params object[] keyValues)
        {
            return await DbContext.Set<T>().FindAsync(keyValues);
        }

        public async Task<PagingResult<TResult>> GetListPagingAsync<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector, int pageIndex, int pageSize, string order, string sort)
        {
            var temp = DbContext.Set<T>().Where<T>(whereLambda);
            var count = await temp.CountAsync();
            temp = temp.SetQueryableOrder(sort, order).Skip(pageSize * (pageIndex - 1))
                     .Take(pageSize);
            var list = await temp.Select(selector).ToListAsync();
            return new PagingResult<TResult>
            {
                Count = count,
                Items = list,
                Index = pageIndex,
                Size = pageSize,
                Total = count % pageSize == 0 ? count / pageSize : count / pageSize + 1
            };
        }

        public async Task<List<TResult>> ListAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda)
        {
            return await DbContext.Set<T>().Where(whereLambda).Select(selector).ToListAsync();
        }

        public async Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda)
        {
            return await DbContext.Set<T>().Where(whereLambda).Select(selector).FirstOrDefaultAsync();
        }
        #endregion
    }
}
