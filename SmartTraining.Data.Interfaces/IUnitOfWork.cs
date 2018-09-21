using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTraining.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();

        void Commit();

        void RollBack();

        void BeginTransaction();
    }
}
