using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcEnvironmentsDto : BaseCommandModel
    {

        public string odatacontext { get; set; }
        public Value[] value { get; set; }

        public class Value
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public OrcRobotDto.Value[] Robots { get; set; }
            public string Type { get; set; }
            public int Id { get; set; }
        }
    }
}
