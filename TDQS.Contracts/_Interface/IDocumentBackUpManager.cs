using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDQS.Contracts
{
    /// <summary>
    /// 电网自动备份接口
    /// </summary>
    public interface IDocumentBackUpManager
    {
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="document"></param>
        void Register(IDocument document);

        /// <summary>
        /// 反注册
        /// </summary>
        void UnRegister();

        
    }
}
