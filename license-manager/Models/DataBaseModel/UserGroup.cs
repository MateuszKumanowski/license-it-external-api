using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace licenseItExternal.Models.DataBaseModel
{
    public class UserGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [ForeignKey("User")]
        public int IdUser { get; set; } //Foreign key for User

        [ForeignKey("Group")]
        public int IdGroup { get; set; } //Foreign key for Group
        
       
    }
}
