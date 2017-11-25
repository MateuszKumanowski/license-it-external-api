using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenseItExternal.Models.DataBaseModel
{
    public class Clients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Group")]
        public int IdGroup { get; set; }

        public string Name { get; set; }

        public DateTime? Creation { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Updated { get; set; }
    }
}