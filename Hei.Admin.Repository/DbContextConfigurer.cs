using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Hei.Admin.Repository
{
    public static class HuachDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HuachDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HuachDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
