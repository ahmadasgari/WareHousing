using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHousingApi.DataModel.Services.Interface;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class EntityTransaction :IEntityTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EntityTransaction(ApplicationDbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }
        public void Commit()
        {
            _transaction.Commit();
        }
        public void RollBack()
        {
            _transaction.Rollback();
        }
        public void Dispose()
        {
            _transaction.Dispose();
        }

     
    }
}
