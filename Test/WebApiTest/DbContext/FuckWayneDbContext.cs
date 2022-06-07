using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest.Models
{
    public class FuckWayneDbContext : DbContext
    {
        public FuckWayneDbContext(DbContextOptions<FuckWayneDbContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<RoleInfo> RoleInfos { get; set; }
    }
}
