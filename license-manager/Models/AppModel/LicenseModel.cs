using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace licenseItExternal.Models.AppModel
{
    public class LicenseModel
    {
        [Key]
        [DataMember(Name = "isActive")]
        public bool IsActive { get; set; }

        [DataMember(Name = "assignedVersion")]
        public decimal AssignedVersion { get; set; }

        [DataMember(Name = "expiration")]
        public DateTime? Expiration { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
