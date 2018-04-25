using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcJobsDto : BaseCommandModel
    {
        public string odatacontext { get; set; }
        public int odatacount { get; set; }
        public Value[] value { get; set; }

        public class Value
        {
            public string Key { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string State { get; set; }
            public string Source { get; set; }
            public string BatchExecutionKey { get; set; }
            public string Info { get; set; }
            public DateTime CreationTime { get; set; }
            public object StartingScheduleId { get; set; }
            public int Id { get; set; }
        }

    }
}
