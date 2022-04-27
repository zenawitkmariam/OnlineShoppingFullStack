using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCounselling.Entities
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string RoleId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
