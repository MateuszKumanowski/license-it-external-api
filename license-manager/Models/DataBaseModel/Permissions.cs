using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenseItExternal.Models.DataBaseModel
{
    public class Permissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("License")]
        public int IdLicense { get; set; } //Foreign key for Licenses

        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual Licenses License { get; set; }
    }
}