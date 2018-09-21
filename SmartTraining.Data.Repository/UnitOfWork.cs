using System;
using System.Data.Entity;
using SmartTraining.Data.EntityFramework;
using SmartTraining.Data.Interfaces;

namespace SmartTraining.Data.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private DataContext _dbContext;
        private DbContextTransaction _transaction;

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWork(DataContext context)
        {
            _dbContext = context;
        }



        /// <summary>
        /// This method is to begin a new transaction.
        /// </summary>
        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }


        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// This method rollback the current transaction.
        /// </summary>
        public void RollBack()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction.Dispose();
            }
        }


        /// <summary>
        /// This method saves the current changes.
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            if (_dbContext != null)
            {
                return _dbContext.SaveChanges();
            }
            else
            {
                return -1;
            }

        }

        /// <summary>
        /// This method commit the current transaction.
        /// </summary>
        public void Commit()
        {
            _transaction?.Commit();
            _transaction?.Dispose();
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContext == null) return;

            _dbContext.Dispose();
            _dbContext = null;
        }
    }
}
