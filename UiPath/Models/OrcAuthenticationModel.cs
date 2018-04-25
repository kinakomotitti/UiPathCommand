using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcAuthenticationModel : BaseCommandModel
    {
        #region Request
        public string tenancyName { get; set; }

        public string usernameOrEmailAddress { get; set; }

        public string password { get; set; }
        #endregion

        #region Responce
        public string result { get; set; }
        public object targetUrl { get; set; }
        public bool success { get; set; }
        public object error { get; set; }
        public bool unAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
        #endregion
    }
}

