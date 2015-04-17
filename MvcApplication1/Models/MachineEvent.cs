using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class MachineEvent
    {
            [Key]
            public int Id { get; set; }
            public string assetID { get; set; }
            public string state { get; set; }
            public string ticks { get; set; }
    }
}