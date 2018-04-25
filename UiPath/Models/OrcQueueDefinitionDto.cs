using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcQueueDefinitionDto : BaseCommandModel
    {

        public string odatacontext { get; set; }
        public Value[] value { get; set; }

        public class Value
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int MaxNumberOfRetries { get; set; }
            public bool AcceptAutomaticallyRetry { get; set; }
            public bool EnforceUniqueReference { get; set; }
            public DateTime CreationTime { get; set; }
            public int Id { get; set; }
        }

    }
}
