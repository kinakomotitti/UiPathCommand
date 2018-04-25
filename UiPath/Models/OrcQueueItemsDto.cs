using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Models
{
    class OrcQueueItemsDto
    {

        public class Rootobject
        {
            public string odatacontext { get; set; }
            public Value[] value { get; set; }
        }

        public class Value
        {
            public int QueueDefinitionId { get; set; }
            public OrcQueueDefinitionDto.Value QueueDefinition { get; set; }
            public Processingexception ProcessingException { get; set; }
            public Specificcontent SpecificContent { get; set; }
            public Output Output { get; set; }
            public string OutputData { get; set; }
            public string Status { get; set; }
            public string ReviewStatus { get; set; }
            public int ReviewerUserId { get; set; }
            public Revieweruser ReviewerUser { get; set; }
            public string Key { get; set; }
            public string Reference { get; set; }
            public string ProcessingExceptionType { get; set; }
            public DateTime DueDate { get; set; }
            public string Priority { get; set; }
            public OrcRobotDto.Value Robot { get; set; }
            public DateTime DeferDate { get; set; }
            public DateTime StartProcessing { get; set; }
            public DateTime EndProcessing { get; set; }
            public int SecondsInPreviousAttempts { get; set; }
            public int AncestorId { get; set; }
            public int RetryNumber { get; set; }
            public string SpecificData { get; set; }
            public DateTime CreationTime { get; set; }
            public string Progress { get; set; }
            public string RowVersion { get; set; }
            public int Id { get; set; }
        }

        public class Processingexception
        {
            public string Reason { get; set; }
            public string Details { get; set; }
            public string Type { get; set; }
            public string AssociatedImageFilePath { get; set; }
            public DateTime CreationTime { get; set; }
        }

        public class Specificcontent
        {
            public Dynamicproperties DynamicProperties { get; set; }
        }

        public class Dynamicproperties
        {
        }

        public class Output
        {
            public Dynamicproperties1 DynamicProperties { get; set; }
        }

        public class Dynamicproperties1
        {
        }

        public class Revieweruser
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string UserName { get; set; }
            public string Domain { get; set; }
            public string FullName { get; set; }
            public string EmailAddress { get; set; }
            public bool IsEmailConfirmed { get; set; }
            public DateTime LastLoginTime { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreationTime { get; set; }
            public string AuthenticationSource { get; set; }
            public string Password { get; set; }
            public Userrole[] UserRoles { get; set; }
            public string[] RolesList { get; set; }
            public string[] LoginProviders { get; set; }
            public Organizationunit[] OrganizationUnits { get; set; }
            public string TenancyName { get; set; }
            public string Type { get; set; }
            public int Id { get; set; }
        }

        public class Userrole
        {
            public int UserId { get; set; }
            public int RoleId { get; set; }
            public string UserName { get; set; }
            public string RoleName { get; set; }
            public int Id { get; set; }
        }

        public class Organizationunit
        {
            public string DisplayName { get; set; }
            public int Id { get; set; }
        }

        public class Environment
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public OrcRobotDto.Value[] Robots { get; set; }
            public string Type { get; set; }
            public int Id { get; set; }
        }

    }
}
