using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider.Provider
{
    /// <summary>
    /// 工作单元
    /// 提供一个保存方法，它可以对调用层公开，为了减少连库次数
    /// </summary>
   public interface IUnitOfWork
    {
        /// <summary>
        /// 启动标识
        /// </summary>
       bool IsStart{get;set;}

       /// <summary>
       /// 启动
       /// </summary>
       void Start();
       /// <summary>
       /// 提交更新
       /// </summary>
       void Save();
       /// <summary>
       /// 通过启动标识执行提交，如果已启动，则不提交
       /// </summary>
       void SaveByStart();

       
       
       
    }
}
