using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenseItExternal.Models.DataBaseModel
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("Group")]
        public int IdGroup { get; set; }
        public string Name { get; set; }
        public decimal Version { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string Hash { get; set; }
        public DateTime Creation { get; set; }
    }
}