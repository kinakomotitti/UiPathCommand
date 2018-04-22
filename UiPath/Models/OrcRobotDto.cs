using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcRobotDto
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
            public object Description { get; set; }
            public string Type { get; set; }
            public object Password { get; set; }
            public string RobotEnvironments { get; set; }
            public int Id { get; set; }
        }

    }
}
