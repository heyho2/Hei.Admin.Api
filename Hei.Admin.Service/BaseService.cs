using Hei.Admin.Core;
using Hei.Admin.IRepository;
using Hei.Admin.Models;
using Hei.Admin.ViewModel.Base;
using Hei.Admin.ViewModel.User;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Hei.Admin.Service
{
    public class BaseService<T> : IService, IDisposable where T : BaseModel
    {
        private readonly IBaseRepository<T> _repository = null;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo CurrentUser => new UserInfo();
        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> whereLambda)
        {
            return _repository.Where(whereLambda);
        }
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary> 
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T FirstOrDefault(Expression<Func<T, bool>> whereLambda)
        {
            return _repository.FirstOrDefault(whereLambda);
        }
        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="total">总条数</param>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="order">DESC/ASC</param>
        /// <param name="sort">排序字段</param>
        /// <returns></returns>
        public TResult GetListPaging<TSelect, TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TSelect>> selector, BasePagingRequest request) where TSelect : BaseItemResponse where TResult : BasePagingResponse<TSelect>, new()
        {
            var result = _repository.GetListPaging(whereLambda, selector, out int total, request.PageIndex, request.PageSize, request.Direction, request.SortField);
            var resultItems = result.ToList();
            return new TResult
            {
                Count = total,
                Total = total % request.PageSize == 0 ? total / request.PageSize : total / request.PageSize + 1,
                Items = resultItems
            };
        }
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public T Find(params object[] keyValues)
        {
            return _repository.Find(keyValues);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> delLambda)
        {
            return _repository.Delete(delLambda);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public int Add(T entity)
        {
            entity.CreateBy = CurrentUser.Id;
            entity.CreateDate = DateTime.Now;
            entity.ModifyBy = 0;
            entity.Disable = (short)BaseModel.DisableEnum.Normal;
            return _repository.Add(entity);
        }
        /// <summary>
        /// 修改
        /// 注意：主键必须传回
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            entity.ModifyBy = CurrentUser.Id;
            entity.ModifyDate = DateTime.Now;
            entity.Disable = (short)BaseModel.DisableEnum.Normal;
            return _repository.Update(entity);
        }
        /// <summary>
        /// 禁用
        /// 注意：主键必须传回
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public int Disable(int id)
        {
            var entity = _repository.Find(id);
            entity.ModifyBy = CurrentUser.Id;
            entity.ModifyDate = DateTime.Now;
            entity.Disable = (short)BaseModel.DisableEnum.Disable;
            return _repository.Update(entity);
        }
        /// <summary>
        /// ioc 容器自动释放资源
        /// 那这个继承IDispose 也没必要写了
        /// 因为注册DbContext， ioc 也会自动调用 DbContext的Dispose
        /// </summary>
        public void Dispose()
        {
            _repository.DbContext.Dispose();
        }
    }
}
