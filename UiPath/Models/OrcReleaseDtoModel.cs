using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcReleaseDtoModel
    {
        public string odatacontext { get; set; }
        public int odatacount { get; set; }
        public Value[] value { get; set; }

        public class Value
        {
            public string Key { get; set; }
            public string ProcessKey { get; set; }
            public string ProcessVersion { get; set; }
            public bool IsLatestVersion { get; set; }
            public bool IsProcessDeleted { get; set; }
            public string Description { get; set; }
            public string Name { get; set; }
            public int EnvironmentId { get; set; }
            public string EnvironmentName { get; set; }
            public int Id { get; set; }
        }
    }
}
