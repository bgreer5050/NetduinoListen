using NetduinoListen.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NetduinoListen
{
    public class context : DbContext
    {

        public DbSet<MachineEvent> machineEvents { get; set; }

    }
}