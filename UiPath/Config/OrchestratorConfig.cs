using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Config
{
    public static class OrchestratorConfig
    {
        public static string HostName { get; set; }

        public static string TenantName { get; set; }

        public static string Password { get; set; }

        public static string UserId { get; set; }

        public static List<string> Commands { get; set; } = new List<string>();
    }
}
