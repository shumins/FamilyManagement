using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Provider.Util;
using System.Linq.Expressions;

namespace Provider.Provider
{
    /**
     *  Author  : Arealty
     *  Function: 基类仓储
     *  Date    : 2015-08-19    
     *  Source  : http://www.cnblogs.com/shumin/
     * */
    public class BaseRepository<T>:IBaseRepository<T>where T:class
    {
        //创建EF框架的上下文
        //此处AccountContext是在Util层中在ADO.NET 实体模型加入的时候定义的Entity对应的Container,继承于DbContext
        //DbContext是EF下System.Data.Entity下  EntityState也是在EF的System.Data下
        private DbContext db;
        protected UnitOfWork UnitOfWork { get; private set; }


        protected BaseRepository(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            //db = new AccountContext();
        }

        

        //private IUnitOfWork _UnitOfWork;
        //private DbContext Content;
        //public BaseRepository(IUnitOfWork UnitOfWork)
        //{
        //    this._UnitOfWork = UnitOfWork;
        //    Content = (DbContext)UnitOfWork;
        //}
         
        /// <summary>
        /// 实现对数据库的添加功能,添加实现EF框架的引用
        /// </summary>
        public T Add(T entity)
        {   
             
            //设置Entity的状态---Added
            UnitOfWork.Entry<T>(entity).State = EntityState.Added;
            UnitOfWork.SaveByStart();
            //保存修改
           // db.SaveChanges();

            return entity;
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        public bool Update(T entity)
        {
            //对上下文中的给定实体执行 CRUD 操作 
            //将给定实体EntityState.Unchanged 状态附加到上下文中
            UnitOfWork.Set<T>().Attach(entity);

            UnitOfWork.Entry<T>(entity).State = EntityState.Modified;

            return UnitOfWork.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        public bool Delete(T entity)
        {
            //对上下文中的给定实体执行 CRUD 操作 
            //将给定实体EntityState.Unchanged 状态附加到上下文中
            UnitOfWork.Set<T>().Attach(entity);

            UnitOfWork.Entry<T>(entity).State = EntityState.Deleted;

            return UnitOfWork.SaveChanges() > 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        public IQueryable<T> Select(Func<T, bool> whereLambda)
        {
            return UnitOfWork.Set<T>().Where<T>(whereLambda).AsQueryable();
        }

        /// <summary>
        /// 针对查询的分页
        /// </summary>
        /// <typeparam name="S">需要针排序的类</typeparam>
        /// <param name="pageIndex">页序</param>
        /// <param name="pageSize">每页数</param>
        /// <param name="total">总共数</param>
        /// <param name="whereLambda">where条件对应的表达式</param>
        /// <param name="isAsc">是否升序</param>
        /// <param name="orderLambda">order条件表达式</param>
        public IQueryable<T> Select<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderLambda)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            total = temp.Count(); //得到总的条数
            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);
            }

            return temp.AsQueryable();
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        public IQueryable<T> Find()
        {
            return UnitOfWork.Set<T>();
        }
        /// <summary>
        /// 判断实体是否存在
        /// </summary>
        /// <param name="predicate">条件</param>
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return Find().Any(predicate);
        }

    }
}
