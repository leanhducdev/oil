using System;
using System.Collections.Generic;
using System.Text;

namespace OilCoreApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call savechang from db context
        /// </summary>
        void Commit();
    }
}
