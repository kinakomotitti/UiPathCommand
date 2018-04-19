using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KUiPath.Models
{
    class OrchestartorModel : BaseCommandModel
    {
        public string HostName { get; set; }

        public string TenantName { get; set; }

        public string Password { get; set; }

        public string UserId { get; set; }

        public List<string> Commands { get; set; } = new List<string>();

    }
}
