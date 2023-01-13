using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
     class PermissionsRepository: GenericRepository<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(ChallengeContext context): base(context) { }
    }
}
