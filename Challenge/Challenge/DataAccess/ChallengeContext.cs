using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChallengeContext: DbContext
    {
        public ChallengeContext(DbContextOptions options): base(options) { }

        public DbSet<Permissions> Permissions { get; set; }

        public DbSet<PermissionTypes> PermissionTypes { get; set; }

    }
}
