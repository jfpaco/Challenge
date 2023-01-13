using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ChallengeContext context;

        public UnitOfWork(ChallengeContext context)
        {
            this.context = context;
            Permissions = new PermissionsRepository(this.context);
            PermissionTypes = new PermissionTypeRepository(this.context);
        }

        public IPermissionsRepository Permissions { get; private set; }
        public IPermissionTypeRepository PermissionTypes { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }


    }
}
