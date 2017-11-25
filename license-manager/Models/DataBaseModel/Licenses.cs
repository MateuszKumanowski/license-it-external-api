using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenseItExternal.Models.DataBaseModel
{
    public class Licenses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Application")]
        public int IdApplication { get; set; } //Foreign key for Application

        [ForeignKey("Clients")]
        public int IdClients { get; set; } //Foreign key for Application

        public string Number { get; set; }
        public decimal AssignedVersion { get; set; }
        public bool IsActive { get; set; }
        public bool IsActivated { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime Creation { get; set; }
        public DateTime? Inclusion { get; set; }
        public DateTime? Expiration { get; set; }
        public DateTime? LastCheck { get; set; }
        public string LastCheckIdentityNumber { get; set; }
        
        public virtual IEnumerable<Permissions> Permissions { get; set; }
        public virtual Application Application { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
