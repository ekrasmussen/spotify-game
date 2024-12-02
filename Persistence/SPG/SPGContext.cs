using Core.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class SPGContext(DbContextOptions<SPGContext> options) : DbContext(options), ISPGContext, IValidationContext
    {

    }
}
