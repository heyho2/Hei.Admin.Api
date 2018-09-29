using Hei.Admin.Core;
using Hei.Admin.IRepository;
using Hei.Admin.Models;
using Hei.Admin.ViewModel.Base;
using Hei.Admin.ViewModel.User;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hei.Admin.Service
{
    public class BaseService<T> : IService, IDisposable where T : BaseModel
    {
        private readonly IBaseRepository<T> _repository;
        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        UserInfo CurrentUser => new UserInfo();
        /// <summary>
        /// 实现对数据库的查询  --简单单行查询
        /// </summary> 
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task<TResult> FirstOrDefaultAsync<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> whereLambda)
        {
            return await _repository.FirstOrDefaultAsync(selector, whereLambda);
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
        public async Task<TResult> GetListPaging<TSelect, TResult>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TSelect>> selector, BasePagingRequest request) where TSelect : BaseItemResponse where TResult : BasePagingResponse<TSelect>, new()
        {
            var result = await _repository.GetListPagingAsync(whereLambda, selector, request.PageIndex, request.PageSize, request.Direction, request.SortField);
            return new TResult
            {
                Count = result.Count,
                Total = result.Total,
                Items = result.Items
            };
        }
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(params object[] keyValues)
        {
            return await _repository.FindAsync(keyValues);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync(Expression<Func<T, bool>> delLambda)
        {
            return await _repository.DeleteAsync(delLambda);
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public async Task<int> AddAsync(T entity)
        {
            entity.CreateBy = CurrentUser.Id;
            entity.CreateDate = DateTime.Now;
            entity.ModifyBy = 0;
            entity.Disable = (short)BaseModel.DisableEnum.Normal;
            return await _repository.AddAsync(entity);
        }
        /// <summary>
        /// 修改
        /// 注意：主键必须传回
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public async Task<int> Update(T entity)
        {
            entity.ModifyBy = CurrentUser.Id;
            entity.ModifyDate = DateTime.Now;
            entity.Disable = (short)BaseModel.DisableEnum.Normal;
            return await _repository.UpdateAsync(entity);
        }
        /// <summary>
        /// 禁用
        /// 注意：主键必须传回
        /// </summary>
        /// <param name="delLambda"></param>
        /// <returns></returns>
        public async Task<int> DisableAsync(int id)
        {
            var entity = _repository.Find(id);
            entity.ModifyBy = CurrentUser.Id;
            entity.ModifyDate = DateTime.Now;
            entity.Disable = (short)BaseModel.DisableEnum.Disable;
            return await _repository.UpdateAsync(entity);
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
