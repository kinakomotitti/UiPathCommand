using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcSettingsDto
    {

        public string odatacontext { get; set; }
        public int odatacount { get; set; }
        public Setting[] value { get; set; }

        public class Setting
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public object Scope { get; set; }
            public string Id { get; set; }
        }

    }
}
