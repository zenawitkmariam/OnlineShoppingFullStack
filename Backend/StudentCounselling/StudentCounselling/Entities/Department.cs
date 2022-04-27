using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentCounselling.Entities
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string DepartmentId { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public string Code { get; set; }
    }
}
