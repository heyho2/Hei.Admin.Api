using ServiceStack.Redis;
using System;

namespace Hei.Admin.Core.Redis
{
    /// <summary>
    /// RedisBase类，是redis操作的基类，继承自IDisposable接口，主要用于释放内存
    /// </summary>
    public abstract class RedisBase : IDisposable
    {
        public IRedisClient IClient { get; private set; }
        public RedisBase()
        {
            IClient = RedisManager.GetClient();
        }

        //public static IRedisClient iClient { get; private set; }
        //static RedisBase()
        //{
        //    iClient = RedisManager.GetClient();
        //}

        public virtual void FlushAll()
        {
            IClient.FlushAll();
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    IClient.Dispose();
                    IClient = null;
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 保存数据DB文件到硬盘
        /// </summary>
        public void Save()
        {
            IClient.Save();
        }

        /// <summary>
        /// 异步保存数据DB文件到硬盘
        /// </summary>
        public void SaveAsync()
        {
            IClient.SaveAsync();
        }
    }
}
