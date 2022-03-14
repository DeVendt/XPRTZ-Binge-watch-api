#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using XPRTZ_Binge_watch_api.Models;

namespace XPRTZ_Binge_watch_api.Data
{
    public class XPRTZ_Binge_watch_apiContext : DbContext
    {
        public XPRTZ_Binge_watch_apiContext (DbContextOptions<XPRTZ_Binge_watch_apiContext> options)
            : base(options)
        {
        }

        public DbSet<XPRTZ_Binge_watch_api.Models.Show> Show { get; set; }
    }
}
