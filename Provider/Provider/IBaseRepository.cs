using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Provider
{
    public interface IBaseRepository<T> 
    {
        /// <summary>
        /// 实现对数据库的添加功能,添加实现EF框架的引用
        /// </summary>
        T Add(T entity);

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        bool Update(T entity);

        /// <summary>
        /// 删除操作
        /// </summary>
        bool Delete(T entity);

        /// <summary>
        /// 查询
        /// </summary>
        IQueryable<T> Select(Func<T, bool> whereLambda);

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
        IQueryable<T> Select<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderLambda);


        IQueryable<T> Find();
    }
}
