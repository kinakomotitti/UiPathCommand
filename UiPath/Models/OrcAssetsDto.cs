using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    public class OrcAssetsDto : BaseCommandModel
    {
        public string odatacontext { get; set; }
        public AssetValue[] value { get; set; }

        public class AssetValue
        {
            public string Name { get; set; }
            public bool CanBeDeleted { get; set; }
            public string ValueScope { get; set; }
            public string ValueType { get; set; }
            public string Value { get; set; }
            public string StringValue { get; set; }
            public bool BoolValue { get; set; }
            public int IntValue { get; set; }
            public string CredentialUsername { get; set; }
            public string CredentialPassword { get; set; }
            public Keyvaluelist[] KeyValueList { get; set; }
            public Robotvalue[] RobotValues { get; set; }
            public int Id { get; set; }
        }

        public class Keyvaluelist
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }

        public class Robotvalue
        {
            public int RobotId { get; set; }
            public string RobotName { get; set; }
            public string KeyTrail { get; set; }
            public string ValueType { get; set; }
            public string StringValue { get; set; }
            public bool BoolValue { get; set; }
            public int IntValue { get; set; }
            public string Value { get; set; }
            public string CredentialUsername { get; set; }
            public string CredentialPassword { get; set; }
            public Keyvaluelist1[] KeyValueList { get; set; }
            public int Id { get; set; }
        }

        public class Keyvaluelist1
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    }
}
