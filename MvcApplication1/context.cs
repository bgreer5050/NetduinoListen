using MvcApplication1.Controllers;
using MvcApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MvcApplication1
{
    public class context : DbContext
    {

        public DbSet<MachineEvent> machineEvents { get; set; }

    }
}