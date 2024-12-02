using Core.Common.Interfaces;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SPG
{
    public class SPGContext(DbContextOptions<SPGContext> options) : DbContext(options), ISPGContext, IValidationContext
    {
        public virtual DbSet<UserUpdate> UserUpdate => Set<UserUpdate>();
    }
}
