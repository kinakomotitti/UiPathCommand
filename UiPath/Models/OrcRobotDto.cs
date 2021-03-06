﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcRobotDto : BaseCommandModel
    {

        public string odatacontext { get; set; }
        public int odatacount { get; set; }
        public Value[] value { get; set; }


        public class Value
        {
            public string LicenseKey { get; set; }
            public string MachineName { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Description { get; set; }
            public string Type { get; set; }
            public string Password { get; set; }
            public string RobotEnvironments { get; set; }
            public int Id { get; set; }
        }
    }
}
