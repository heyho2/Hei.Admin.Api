using Hei.Admin.Core.EntityFrameworkExtend;
using Hei.Admin.IRepository;
using Hei.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        public IQueryable<T> Where(Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().AsNoTracking().Where<T>(whereLambda).AsQueryable();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> whereLambda)
        {
            return DbContext.Set<T>().AsNoTracking().FirstOrDefault<T>(whereLambda);
        }

        public T Find(params object[] keyValues)
        {
            return DbContext.Set<T>().Find(keyValues);
        }

        public List<TResult> GetListPaging<TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TResult>> selector, out int total, int pageIndex, int pageSize, string order, string sort)
        {
            var temp = DbContext.Set<T>().Where<T>(whereLambda);
            total = temp.Count();
            temp = temp.SetQueryableOrder(sort, order).Skip(pageSize * (pageIndex - 1))
                     .Take(pageSize);
            return temp.Select(selector).ToList();
        }
    }
}