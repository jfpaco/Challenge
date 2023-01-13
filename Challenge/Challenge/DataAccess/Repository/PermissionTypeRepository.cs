using Domain.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    class PermissionTypeRepository : GenericRepository<PermissionTypes>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(ChallengeContext context) : base(context) { }

    }
}
